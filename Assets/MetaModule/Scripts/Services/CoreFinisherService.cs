using Core.Game;
using Cysharp.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Screens;
using UnityEngine;

namespace Infrastructure.Services
{
    public class CoreFinisherService : IInitializableService, IPostInitializableService, IUpdatableService
    {
        private GameLifecycleService _gameLifecycleService;
        private GameResultService _gameResultService;
        private PlayerDataService _playerDataService;
        private LevelsService _levelsService;
        private IGameService _gameService;
        private ITargetsService _targetsService;

        private WinScreen _winScreen;
        private LoseScreen _loseScreen;
        private GameScreen _gameScreen;

        public void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _gameResultService = ServiceLocator.GetService<GameResultService>();
            _playerDataService = ServiceLocator.GetService<PlayerDataService>();
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _gameService = ServiceLocator.GetService<IGameService>();
            _targetsService = ServiceLocator.GetService<ITargetsService>();
            
            _gameScreen = ScreenLocator.GetScreen<GameScreen>();
            _winScreen = ScreenLocator.GetScreen<WinScreen>();
            _loseScreen = ScreenLocator.GetScreen<LoseScreen>();
        }

        public void PostInitialize()
        {
            SubscribeOnTargetsCollection();
        }

        private void SubscribeOnTargetsCollection()
        {
            if (_targetsService is { Enabled: true })
                _targetsService.TargetsCollected += AllTargetsCollected;
        }

        private void AllTargetsCollected()
        {
            _gameLifecycleService.SetPause(true);
            FinishGameByTargets().Forget();
        }

        private async UniTaskVoid FinishGameByTargets()
        {
            await UniTask.WaitForSeconds(_targetsService.DelayBeforeWin);
            WinGame();
        }

        public void WinGame()
        {
            FinishGame(GameResult.Win);
            
            _levelsService.SetNextLevel();
            
            ShowResultScreen(GameResult.Win);
        }

        public void LoseGame()
        {
            FinishGame(GameResult.Lose);
            ShowResultScreen(GameResult.Lose);
        }

        private void FinishGame(GameResult gameResult)
        {
            _gameLifecycleService.StopGame();
            _gameResultService.CalculateGameResult(gameResult);
            _playerDataService.UpdateCurrentLevelProgress();
            _playerDataService.SavePlayerData();
            
            _gameService?.ClearField();

            _gameScreen.Hide();
        }

        private void ShowResultScreen(GameResult gameResult)
        {
            if (gameResult == GameResult.Win)
                _winScreen.Show();
            else
                _loseScreen.Show();
        }

        public void UpdateService(float deltaTime)
        {
#if UNITY_EDITOR
            if (Input.GetKeyUp(KeyCode.W)) 
                WinGame();
            if (Input.GetKeyUp(KeyCode.L))
                LoseGame();
#endif
        }
    }
}