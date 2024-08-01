using Infrastructure.Attributes;
using UnityEngine;

namespace Infrastructure.Core
{
    [TopmostComponent]
    public abstract class MetaViewBase : MonoBehaviour
    {
        public virtual void Initialize()
        {
        }

        public virtual void Hide()
        {
        }

        public virtual void UpdateView()
        {
        }
    }
}