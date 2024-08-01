using Infrastructure.Attributes;
using Infrastructure.Services;
using Infrastructure.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Components
{
    [RequireComponent(typeof(Selectable))]
    [TopmostComponent]
    public class PlaySfxOnValueChanged : MonoBehaviour
    {
        private SoundService _soundService;
        private SoundSettings _soundSettings;

        private void Start()
        {
            _soundService = ServiceLocator.GetService<SoundService>();
            _soundSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<SoundSettings>();
            
            RegisterCall();
        }

        private void RegisterCall()
        {
            if (TryGetComponent<Toggle>(out var toggle))
                toggle.onValueChanged.AddListener(value => PlayAudioCLip());
            
            if (TryGetComponent<Slider>(out var slider))
                slider.onValueChanged.AddListener(value => PlayAudioCLip());
        }

        private void PlayAudioCLip()
        {
            _soundService.PlaySound(_soundSettings.Click);
        }
    }
}