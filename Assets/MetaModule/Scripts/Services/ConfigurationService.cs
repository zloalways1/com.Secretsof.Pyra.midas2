using Infrastructure.Common;
using Infrastructure.Core;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ConfigurationService : MonoService, IInitializableService
    {
        [SerializeField] public Configuration Configuration;
        
        private TypedDictionary<SettingsBase> _settingsCache = new TypedDictionary<SettingsBase>();

        public TSettings GetSettings<TSettings>() where TSettings : SettingsBase
        {
            return _settingsCache.Get<TSettings>();
        }

        public void Initialize()
        {
            Configuration.Settings.ForEach(CacheSettings);
        }

        private void CacheSettings(SettingsBase settings)
        {
            if (settings) 
                _settingsCache.Register(settings.GetType(), settings);
        }
    }
}