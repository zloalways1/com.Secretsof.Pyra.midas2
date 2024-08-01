using Infrastructure.Data;
using Random = UnityEngine.Random;

namespace Infrastructure.Services
{
    public class PlayerDataService : IInitializableService
    {
        private int _seedHash => PlayerData.CurrentLevel + 100;
        
        private SaveLoadService _saveLoadService;
        private GameResultService _gameResultService;

        public PlayerData PlayerData { get; private set; }
        
        public void Initialize()
        {
            _saveLoadService = ServiceLocator.GetService<SaveLoadService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            
            InitPlayerData();
        }

        public void SavePlayerData() => _saveLoadService.SavePlayerData(PlayerData);

        public void InitSeed()
        {
            InitRandomSeed();
        }

        public void UpdateCurrentLevelProgress()
        {
            PlayerData.SetCurrentLevelProgress(_gameResultService.GameResultData.Stars);
        }

        private void InitPlayerData()
        {
            PlayerData = _saveLoadService.LoadOrCreatePlayerData();
            PlayerData.OnUpdate += OnUpdatePlayerData;
            
            InitRandomSeed();
        }

        private void OnUpdatePlayerData()
        {
            InitRandomSeed();
            SavePlayerData();
        }

        private void InitRandomSeed() => Random.InitState(_seedHash);
    }
}