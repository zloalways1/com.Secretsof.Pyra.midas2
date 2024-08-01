using Game.Services;
using Infrastructure.Screens;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ScreensService : MonoService, IInitializableService
    {
        [SerializeField] public ScreenBase AfterLoadingScreen;
        [SerializeField] public ScreenBase StopGameScreen;
        
        private SoundService _soundService;
        private BlurService _blurService;

        public void Initialize()
        {
            _soundService = ServiceLocator.GetService<SoundService>();
            _blurService = ServiceLocator.GetService<BlurService>();
        }

        public void PostLoadingAction()
        {
            _blurService.EnableBlur();
            _soundService.PlayBackgroundMusic();
            
            if (AfterLoadingScreen)
                AfterLoadingScreen.Show();
        }

        public void ShowStopGameScreen()
        {
            if (StopGameScreen)
                StopGameScreen.Show();
        }
    }
}