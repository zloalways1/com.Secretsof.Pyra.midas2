using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsSlidersView : OptionsView
    {
        [SerializeField] private Slider SoundSlider;
        [SerializeField] private Slider MusicSlider;

        public override void UpdateView()
        {
            UpdateSliderValues();
        }

        protected override void Subscribe()
        {
            SubscribeSliders();
        }

        private void UpdateSliderValues()
        {
            SoundSlider.value = _soundService.SfxVolume;
            MusicSlider.value = _soundService.MusicVolume;
        }

        private void SubscribeSliders()
        {
            SoundSlider.onValueChanged.AddListener(SoundEnableChanged);
            MusicSlider.onValueChanged.AddListener(MusicEnableChanged);
        }

        private void SoundEnableChanged(float value)
        {
            _soundService.SetSfxVolume(value);
        }

        private void MusicEnableChanged(float value)
        {
            _soundService.SetMusicVolume(value);
        }
    }
}