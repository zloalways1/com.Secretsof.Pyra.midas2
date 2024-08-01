using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsTogglesView : OptionsView
    {
        [SerializeField] private Toggle MusicToggle;
        [SerializeField] private Toggle SfxToggle;
        [SerializeField] private Toggle VibrationToggle;

        public override void UpdateView()
        {
            UpdateToggleValues();
        }

        protected override void Subscribe()
        {
            SubscribeToggles();
        }

        private void SubscribeToggles()
        {
            if (MusicToggle)
                MusicToggle.onValueChanged.AddListener(SwitchEnableMusic);
            
            if (SfxToggle)
                SfxToggle.onValueChanged.AddListener(SwitchEnableSound);
            
            if (VibrationToggle)
                VibrationToggle.onValueChanged.AddListener(SwitchEnableVibration);
        }

        private void UpdateToggleValues()
        {
            if (MusicToggle)
                MusicToggle.isOn = _soundService.MusicEnabled;
            
            if (SfxToggle)
                SfxToggle.isOn = _soundService.SfxEnabled;

            if (VibrationToggle)
                VibrationToggle.isOn = _vibrationService.IsEnabled;
        }

        private void SwitchEnableMusic(bool isOn)
        {
            _soundService.SetMusicEnabled(isOn);
        }

        private void SwitchEnableSound(bool isOn)
        {
            _soundService.SetSfxEnabled(isOn);
        }

        private void SwitchEnableVibration(bool isOn)
        {
            _vibrationService.SetEnabled(isOn);
        }
    }
}