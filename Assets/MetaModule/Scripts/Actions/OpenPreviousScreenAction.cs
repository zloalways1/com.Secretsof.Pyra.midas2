using Infrastructure.Attributes;
using Infrastructure.Services;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 2)]
    public class OpenPreviousScreenAction : ButtonAction
    {
        private CurrentScreenService _currentScreenService;

        public override void Action()
        {
            _currentScreenService.HideCurrentScreen();
            _currentScreenService.ShowPreviousScreen();
        }

        protected override void Initialize()
        {
            _currentScreenService = ServiceLocator.GetService<CurrentScreenService>();
        }
    }
}