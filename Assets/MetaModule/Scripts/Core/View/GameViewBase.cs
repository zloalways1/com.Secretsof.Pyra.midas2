using Infrastructure.Attributes;
using UnityEngine;

namespace Infrastructure.Core
{
    [TopmostComponent]
    public abstract class GameViewBase : MonoBehaviour
    {
        protected ConfigurationProxy _settings { get; private set; }

        public void Construct(ConfigurationProxy _configurationProxy)
        {
            _settings = _configurationProxy;
            
            Initialize();
        }

        protected virtual void Initialize() { }
    }
}