using Infrastructure.Attributes;
using Infrastructure.Services;
using Infrastructure.Settings;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 4)]
    public class PlayClickSoundAction : ButtonAction
    {
        private SoundService _soundService;
        private SoundSettings _soundSettings;

        public override void Action()
        {
            _soundService.PlaySound(_soundSettings.Click);
        }

        protected override void Initialize()
        {
            _soundService = ServiceLocator.GetService<SoundService>();
            _soundSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<SoundSettings>();
        }
    }
}