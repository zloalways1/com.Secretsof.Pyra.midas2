using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Settings;
using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class LevelsScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private LevelView LevelPrefab;
        [SerializeField] private Transform Container;

        private List<LevelView> _createdLevels = new List<LevelView>();

        private ConfigurationService _configurationService;
        private CommonSettings _commonSettings;


        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _commonSettings = _configurationService.GetSettings<CommonSettings>();
        }

        protected override void OnShow()
        {
            CreateLevels();
            RefreshLevelsProgress();
        }

        private void CreateLevels()
        {
            if (_createdLevels.Count > 0)
                return;
            
            for (int i = 0; i < _commonSettings.LevelsCount; i++)
            {
                LevelView levelView = Instantiate(LevelPrefab, Container, false);
                int level = i + 1;
                
                levelView.Initialize();
                levelView.Show(level);
                
                _createdLevels.Add(levelView);
            }
        }

        private void RefreshLevelsProgress()
        {
            _createdLevels.ForEach(levelView =>
            {
                levelView.UpdateView();
            });
        }
    }
}