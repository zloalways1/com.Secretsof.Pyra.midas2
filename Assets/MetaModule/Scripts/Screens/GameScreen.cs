using Infrastructure.ButtonActions;
using Infrastructure.Services;
using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class GameScreen: ScreenBase, IInitializableScreen
    {
        [SerializeField] private CurrentLevelView LevelView;
        [SerializeField] private ScoresView ScoresView;
        [SerializeField] private TimerView TimerView;
        [SerializeField] private TargetsView TargetsView;

        private ScoresService _scoresService;

        public void Initialize()
        {
            _scoresService = ServiceLocator.GetService<ScoresService>();
            _scoresService.ScoresAdded += scores => UpdateScores();
            
            InitializeViews();
        }

        public void StartGame()
        {
            ResetTimer();
        }

        protected override void OnShow()
        {
            ShowViews();

            UpdateScores();
            UpdateLevel();
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void InitializeViews()
        {
            if (ScoresView)
                ScoresView.Initialize();
            if (LevelView)
                LevelView.Initialize();
            if (TimerView)
                TimerView.Initialize();
            if (TargetsView)
                TargetsView.Initialize();
        }

        private void ShowViews()
        {
            if (LevelView)
                LevelView.Show();
            if (ScoresView)
                ScoresView.Show();
            if (TimerView)
                TimerView.Show();
            if (TargetsView)
                TargetsView.Show();
        }

        private void UpdateScores()
        {
            if (ScoresView)
                ScoresView.UpdateView();
        }

        private void UpdateLevel()
        {
            if (LevelView)
                LevelView.UpdateView();
        }

        private void UpdateTimer()
        {
            if (TimerView)
                TimerView.UpdateTimer();
        }

        private void ResetTimer()
        {
            if (TimerView)
                TimerView.ResetTimer();
        }
    }
}