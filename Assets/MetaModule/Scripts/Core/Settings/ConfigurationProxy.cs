using System.Linq;
using Infrastructure.Common;

namespace Infrastructure.Core
{
    public class ConfigurationProxy
    {
        private TypedDictionary<SettingsBase> _settingsCache = new TypedDictionary<SettingsBase>();
        private Configuration _configuration;

        public ConfigurationProxy(Configuration configuration)
        {
            _configuration = configuration;
            CacheModules();
        }
        
        public TSettings GetSettings<TSettings>() where TSettings : SettingsBase
        {
            return _settingsCache.Get<TSettings>();
        }

        private void CacheModules()
        {
            _configuration.Settings.ForEach(CacheSettings);
        }

        private void CacheSettings(SettingsBase settings)
        {
            if (settings) 
                _settingsCache.Register(settings.GetType(), settings);
        }
    }
}