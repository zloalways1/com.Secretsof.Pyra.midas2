using Services.Core;

namespace Infrastructure.Services
{
    public class VibrationService : MonoService, IInitializableService, IPostInitializableService
    {
        private OptionsDataService _optionsDataService;

        public bool IsEnabled => _optionsDataService.OptionsData.VibrationEnabled;

        public void Initialize()
        {
            _optionsDataService = ServiceLocator.GetService<OptionsDataService>();
        }

        public void PostInitialize()
        {
            SetEnabled(_optionsDataService.OptionsData.VibrationEnabled);
            
            // Vibration.Init();
        }

        public void SetEnabled(bool isEnabled)
        {
            _optionsDataService.OptionsData.VibrationEnabled = isEnabled;
        }

        public void PlayFindPairVibration()
        {
            // if (IsEnabled)
                // Vibration.Vibrate();
        }

        public void PlayFinishGameVibration()
        {
            // if (IsEnabled)
                // Vibration.VibrateNope();
        }

        public void SaveSettings()
        {
            _optionsDataService.Save();
        }

        public void SwitchVibrationEnabled()
        {
            bool isEnabled = !_optionsDataService.OptionsData.VibrationEnabled;
            _optionsDataService.OptionsData.VibrationEnabled = isEnabled;
        }
    }
}