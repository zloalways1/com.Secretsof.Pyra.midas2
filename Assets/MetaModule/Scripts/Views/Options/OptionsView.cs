using Infrastructure.Attributes;
using Infrastructure.Core;
using Infrastructure.Services;

namespace Infrastructure.Views
{
    [TopmostComponent]
    public abstract class OptionsView : MetaView
    {
        protected SoundService _soundService;
        protected VibrationService _vibrationService;

        public override void Initialize()
        {
            _soundService = ServiceLocator.GetService<SoundService>();
            _vibrationService = ServiceLocator.GetService<VibrationService>();
            
            Subscribe();
        }
        
        public override void Show()
        {
            UpdateView();
        }

        public override void Hide()
        {
            _soundService.SaveSettings();
            _vibrationService.SaveSettings();
        }

        protected abstract void Subscribe();
    }
}