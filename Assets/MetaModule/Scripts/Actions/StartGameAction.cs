using Infrastructure.Attributes;
using Infrastructure.Screens;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class StartGameAction : ButtonAction
    {
        private CoreStarterService _coreStarterService;
        private MenuScreen _menuScreen;

        public override void Action()
        {
            if (_menuScreen)
                _menuScreen.Hide();
            
            _coreStarterService.StartCore();
        }

        protected override void Initialize()
        {
            _coreStarterService = ServiceLocator.GetService<CoreStarterService>();
            _menuScreen = ScreenLocator.GetScreen<MenuScreen>();
        }
    }
}