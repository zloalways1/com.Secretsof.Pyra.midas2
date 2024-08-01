using Infrastructure.Attributes;
using Infrastructure.Screens;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 2)]
    public class OpenScreenAction : ButtonAction
    {
        [SerializeField] public ScreenBase Screen;

        private CurrentScreenService _currentScreenService;

        public override void Action()
        {
            _currentScreenService.HideCurrentScreen();
            Screen.Show();
        }

        protected override void Initialize()
        {
            _currentScreenService = ServiceLocator.GetService<CurrentScreenService>();
        }
    }
}