using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TopmostComponentAttribute : Attribute
    {
        public int Order { get; set; }
    }
#if UNITY_EDITOR
    public static class TopmostComponentHandler
    {
        public static void CorrectComponentOrder(Component component)
        {
            Internal.TopmostComponentHandler.CorrectComponentOrder(component);
        }
    }
#endif
}

#if UNITY_EDITOR

namespace Infrastructure.Attributes.Internal
{
    using UnityEditor;
    using UnityEngine;
    using System.Reflection;

    internal static class TopmostComponentHandler
    {
        public static void CorrectComponentOrder(Component component)
        {
            OnComponentAdded(component);
        }
        
        [InitializeOnLoadMethod]
        private static void HandleAddComponent()
        {
            ObjectFactory.componentWasAdded -= OnComponentAdded;
            ObjectFactory.componentWasAdded += OnComponentAdded;
        }
        
        private static void OnComponentAdded(Component addedComponent)
        {
            List<Component> topMostComponents = addedComponent.gameObject.GetComponents<Component>()
                .ToList()
                .Where(HasTopmostAttribute)
                .OrderBy(GetOrder)
                .ToList();
                
            foreach (Component component in topMostComponents)
            {
                while (UnityEditorInternal.ComponentUtility.MoveComponentUp(component))
                {
                }

                int order = GetActualOrder(topMostComponents, component);

                for (int i = 0; i < order; i++)
                    UnityEditorInternal.ComponentUtility.MoveComponentDown(component);
            }

            bool HasTopmostAttribute(Component component) =>
                component.GetType().IsDefined(typeof(TopmostComponentAttribute), true);

            int GetOrder(Component component) => ((TopmostComponentAttribute)component.GetType()
                .GetCustomAttribute(typeof(TopmostComponentAttribute))).Order;

            int GetActualOrder(List<Component> topmostComponents, Component myComponent) =>
                topmostComponents
                    .Count(component => GetOrder(component) < GetOrder(myComponent));
        }
    }
}

#endif