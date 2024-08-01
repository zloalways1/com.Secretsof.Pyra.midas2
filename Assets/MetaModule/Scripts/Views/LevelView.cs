using System.Collections.Generic;
using Infrastructure.Core;
using Infrastructure.Data;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class LevelView : MetaView<int>
    {
        [SerializeField] private TMP_Text LevelNumber;
        [SerializeField] private Button LevelButton;
        [SerializeField] private GameObject HideWhenLocked;
        [SerializeField] private GameObject ShowWhenLocked;
        [SerializeField] private List<LevelStarData> ProgressStars;
        
        private int _level;
        
        private LevelsService _levelsService;
        private StartLevelService _startLevelService;

        public override void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _startLevelService = ServiceLocator.GetService<StartLevelService>();
            
            LevelButton.onClick.AddListener(TryStartLevel);
        }

        public override void Show(int level)
        {
            _level = level;
            UpdateView();
        }

        public override void UpdateView()
        {
            UpdateLevel();
            UpdateUnlockedState();
            UpdateProgressStars();
        }

        private void TryStartLevel()
        {
            _startLevelService.StartLevelIfUnlocked(_level);
        }

        private void UpdateLevel()
        {
            LevelNumber.text = _level.ToString(format:"00");
        }

        private void UpdateUnlockedState()
        {
            bool isUnlocked = _levelsService.IsLevelUnlocked(_level);
            HideWhenLocked.SetActive(isUnlocked);
            ShowWhenLocked.SetActive(!isUnlocked);
        }

        private void UpdateProgressStars()
        {
            int stars = _levelsService.GetLevelProgress(_level);
            ProgressStars.ForEach(progressStar =>
            {
                bool starActive = ProgressStars.IndexOf(progressStar) < stars;
                progressStar.Star.SetActive(starActive);
                progressStar.Back.SetActive(!starActive);
            });
        }
    }
}