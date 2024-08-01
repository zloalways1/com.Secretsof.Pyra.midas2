using Core.Game;
using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class CoreStarterService : IInitializableService
    {
        private TimerService _timerService;
        private GameLifecycleService _gameLifecycleService;
        private GameResultService _gameResultService;
        private ScoresService _scoresService;
        private PlayerDataService _playerDataService;
        private IGameService _gameStarterService;
        private ITargetsService _targetsService;
        
        private GameScreen _gameScreen;

        public void Initialize()
        {
            _timerService = ServiceLocator.GetService<TimerService>();
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _scoresService = ServiceLocator.GetService<ScoresService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            _gameStarterService = ServiceLocator.GetService<IGameService>();
            _targetsService = ServiceLocator.GetService<ITargetsService>();
            
            _gameScreen = ScreenLocator.GetScreen<GameScreen>();
        }

        public void StartCore()
        {
            ResetServices();
            StartServices();
            ShowGameScreen();
            
            _gameStarterService?.CreateField();
        }

        private void ResetServices()
        {
            _scoresService.ResetScores();
            _gameResultService.ResetGameResult();
        }

        private void StartServices()
        {
            _playerDataService.InitSeed();
            _timerService.StartTimer();
            _gameLifecycleService.StartGame();
            _targetsService?.CreateTargets();
        }

        private void ShowGameScreen()
        {
            _gameScreen.Show();
            _gameScreen.StartGame();
        }
    }
}