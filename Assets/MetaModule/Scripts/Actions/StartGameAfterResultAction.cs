using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    public class StartGameAfterResultAction : ButtonAction
    {
        private CoreStarterService _coreStarterService;
        private CurrentScreenService _currentScreenService;

        public override void Action()
        {
            _currentScreenService.HideCurrentScreen();
            _coreStarterService.StartCore();
        }

        protected override void Initialize()
        {
            Order = 1;
            _coreStarterService = ServiceLocator.GetService<CoreStarterService>();
            _currentScreenService = ServiceLocator.GetService<CurrentScreenService>();
        }
    }
}