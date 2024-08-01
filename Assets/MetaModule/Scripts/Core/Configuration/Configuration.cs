using System.Collections.Generic;
using Infrastructure.Core;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Infrastructure.Common
{
    [CreateAssetMenu(order = 0)]
    public class Configuration : ScriptableObject
    {
        [SerializeField] public List<SettingsBase> Settings;
    }
}