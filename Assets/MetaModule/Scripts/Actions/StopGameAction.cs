using Core.Game;
using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class StopGameAction : ButtonAction
    {
        private GameLifecycleService _gameLifecycleService;
        private CurrentScreenService _currentScreenService;
        private ScreensService _screensService;
        private IGameService _gameService;

        public override void Action()
        {
            _gameLifecycleService.StopGame();
            _gameService?.ClearField();
            _currentScreenService.HideCurrentScreen();
            _screensService.ShowStopGameScreen();
        }

        protected override void Initialize()
        {
            Order = 1;
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
            _currentScreenService = ServiceLocator.GetService<CurrentScreenService>();
            _screensService = ServiceLocator.GetService<ScreensService>();
            _gameService = ServiceLocator.GetService<IGameService>();
        }
    }
}