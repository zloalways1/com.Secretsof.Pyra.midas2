using Infrastructure.Settings;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class SoundService : MonoService, IInitializableService, IPostInitializableService
    {
        [SerializeField] public AudioSource SoundAudioSource;
        [SerializeField] public AudioSource MusicAudioSource;
        
        private OptionsDataService _optionsDataService;
        private ConfigurationService _configurationService;
        private SoundSettings _soundSettings;

        public bool SfxEnabled => _optionsDataService.OptionsData.SfxVolume > 0;
        public bool MusicEnabled => _optionsDataService.OptionsData.MusicVolume > 0;
        public float SfxVolume => _optionsDataService.OptionsData.SfxVolume;
        public float MusicVolume => _optionsDataService.OptionsData.MusicVolume;

        public void Initialize()
        {
            _optionsDataService = ServiceLocator.GetService<OptionsDataService>();
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _soundSettings = _configurationService.GetSettings<SoundSettings>();
        }

        public void PostInitialize()
        {
            UpdateVolume();
        }

        public void PlayBackgroundMusic()
        {
            if (_soundSettings.BackMusic && _soundSettings.BackMusic)
            {
                MusicAudioSource.clip = _soundSettings.BackMusic;
                MusicAudioSource.Play();
            }
        }

        public void PlaySound(AudioClip audioClip)
        {
            if (audioClip)
                SoundAudioSource.PlayOneShot(audioClip);
        }

        public void SwitchMusicEnabled()
        {
            int volume = _optionsDataService.OptionsData.MusicVolume > 0 ? 0 : 1;
            _optionsDataService.OptionsData.MusicVolume = volume;
            UpdateVolume();
        }

        public void SwitchSfxEnabled()
        {
            int volume = _optionsDataService.OptionsData.SfxVolume > 0 ? 0 : 1;
            _optionsDataService.OptionsData.SfxVolume = volume;
            UpdateVolume();
        }

        public void SetSfxEnabled(bool isEnabled)
        {
            _optionsDataService.OptionsData.SfxVolume = isEnabled ? 1 : 0;
            UpdateVolume();
        }

        public void SetMusicEnabled(bool isEnabled)
        {
            _optionsDataService.OptionsData.MusicVolume = isEnabled ? 1 : 0;
            UpdateVolume();
        }

        public void SetSfxVolume(float value)
        {
            _optionsDataService.OptionsData.SfxVolume = value;
            UpdateVolume();
        }

        public void SetMusicVolume(float value)
        {
            _optionsDataService.OptionsData.MusicVolume = value;
            UpdateVolume();
        }

        private void UpdateVolume()
        {
            SoundAudioSource.volume = SfxVolume;
            MusicAudioSource.volume = MusicVolume;
        }

        public void SaveSettings()
        {
            _optionsDataService.Save();
        }
    }
}