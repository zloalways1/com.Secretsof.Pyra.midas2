using Infrastructure.ButtonActions;
using Infrastructure.Services;
using Infrastructure.Settings;
using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class WinScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private GameObject ActivateWhenLastLevel;
        [SerializeField] private TimerView TimerView;
        [SerializeField] private StarsView StarsView;
        [SerializeField] private ScoresView ScoresView;
        [SerializeField] private FinishLevelView LevelView;

        private ConfigurationService _configurationService;
        private SoundService _soundService;
        private SoundSettings _soundSettings;
        private LevelsService _levelsService;

        public void Initialize()
        {
            _soundService = ServiceLocator.GetService<SoundService>();
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _soundSettings = _configurationService?.GetSettings<SoundSettings>();
            _levelsService = ServiceLocator.GetService<LevelsService>();
            
            if (TimerView)
                TimerView.Initialize();
            if (StarsView)
                StarsView.Initialize();
            if (ScoresView)
                ScoresView.Initialize();
            if (LevelView)
                LevelView.Initialize();
        }

        protected override void OnShow()
        {
            if (TimerView) 
                TimerView.Show();
            if (StarsView)
                StarsView.Show();
            if (ScoresView)
                ScoresView.Show();
            if (LevelView)
                LevelView.Show();
            
            if (ActivateWhenLastLevel)
                ActivateWhenLastLevel.SetActive(!_levelsService.HasNextLevel());

            _soundService.PlaySound( _soundSettings.WinGame);
        }
    }
}