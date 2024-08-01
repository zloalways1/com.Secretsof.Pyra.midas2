using Infrastructure.Data;
using UnityEngine;

namespace Infrastructure.Services
{
    public class SaveLoadService : IService
    {
        private const string PrefsCurrentLevelKey = "CurrentLevel";
        private const string PrefsLevelsProgressKey = "LevelsProgress";
        
        private const string PrefsSfxVolumeKey = "SfxVolume";
        private const string PrefsMusicVolumeKey = "MusicVolume";
        private const string PrefsVibrationEnabledKey = "Vibro";
        
        public void SavePlayerData(PlayerData playerData)
        {
            PlayerPrefs.SetInt(PrefsCurrentLevelKey, playerData.CurrentLevel);

            string progressJson = JsonUtility.ToJson(playerData.LevelProgress);
            // Debug.Log(progressJson);
            PlayerPrefs.SetString(PrefsLevelsProgressKey, progressJson);
            
            PlayerPrefs.Save();
        }
        
        public void SaveOptionsData(OptionsData optionsData)
        {
            PlayerPrefs.SetFloat(PrefsSfxVolumeKey, optionsData.SfxVolume);
            PlayerPrefs.SetFloat(PrefsMusicVolumeKey, optionsData.MusicVolume);
            PlayerPrefs.SetString(PrefsVibrationEnabledKey, optionsData.VibrationEnabled.ToString());
            
            PlayerPrefs.Save();
        }
        
        public OptionsData LoadOrCreateOptionsData()
        {
            OptionsData optionsData = new OptionsData(1, 1, false);

            if (PlayerPrefs.HasKey(PrefsSfxVolumeKey))
                optionsData.SfxVolume = PlayerPrefs.GetFloat(PrefsSfxVolumeKey);
    
            if (PlayerPrefs.HasKey(PrefsMusicVolumeKey))
                optionsData.MusicVolume = PlayerPrefs.GetFloat(PrefsMusicVolumeKey);
                
            if (PlayerPrefs.HasKey(PrefsVibrationEnabledKey))
                optionsData.VibrationEnabled = bool.Parse(PlayerPrefs.GetString(PrefsVibrationEnabledKey));
            
            return optionsData;
        }

        public PlayerData LoadOrCreatePlayerData()
        {
            PlayerData playerData = new PlayerData(currentLevel: 1);

            if (PlayerPrefs.HasKey(PrefsCurrentLevelKey))
                playerData.SetCurrentLevel(PlayerPrefs.GetInt(PrefsCurrentLevelKey));

            if (PlayerPrefs.HasKey(PrefsLevelsProgressKey))
            {
                string progressJson = PlayerPrefs.GetString(PrefsLevelsProgressKey);
                LevelProgress levelProgress = JsonUtility.FromJson<LevelProgress>(progressJson);
                playerData.SetLevelsProgress(levelProgress);
            }
            
            return playerData;
        }
    }
}