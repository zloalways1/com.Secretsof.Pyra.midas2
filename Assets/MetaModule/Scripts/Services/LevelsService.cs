using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class LevelsService : IInitializableService
    {
        private PlayerDataService _playerDataService;
        private ConfigurationService _configurationService;
        private CommonSettings _commonSettings;

        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            
            _commonSettings = _configurationService.GetSettings<CommonSettings>();
        }

        public int CurrentLevel => _playerDataService.PlayerData.CurrentLevel;

        public int GetLevelProgress(int level)
        {
            return _playerDataService.PlayerData.GetLevelProgress(level);
        }

        public bool IsLevelUnlocked(int level)
        {
            return _playerDataService.PlayerData.GetLevelProgress(level) > 0 ||
                   level <= _playerDataService.PlayerData.MaxUnlockedLevel();
        }

        public bool HasNextLevel()
        {
            return _commonSettings.LevelsCount <= 0 ||
                   _playerDataService.PlayerData.CurrentLevel < _commonSettings.LevelsCount;
        }

        public void SetCurrentLevel(int level)
        {
            _playerDataService.PlayerData.SetCurrentLevel(level);
        }

        public void SetNextLevel()
        {
            _playerDataService.PlayerData.SetNextCurrentLevel();
        }
    }
}