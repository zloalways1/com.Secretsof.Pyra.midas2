using Infrastructure.Core;
using Infrastructure.Services;
using Infrastructure.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class ScoresView : MetaView
    {
        [SerializeField] private TMP_Text Scores;
        [SerializeField] private bool AddScores;
        [SerializeField] private Transform AddScoresRoot;
        [SerializeField] private RectTransform RebuildLayoutRoot;

        private int _scores;
        
        protected ScoresService _scoresService;
        private ScoresSettings _scoresSettings;
        
        public override void Initialize()
        {
            _scoresService = ServiceLocator.GetService<ScoresService>();
            _scoresSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<ScoresSettings>();
        }

        public override void Show()
        {
            UpdateView();
            RebuildLayout();
        }

        private void RebuildLayout()
        {
            if (RebuildLayoutRoot)
                LayoutRebuilder.ForceRebuildLayoutImmediate(RebuildLayoutRoot);
        }

        public override void UpdateView()
        {
            if (_scores != _scoresService.Scores || _scoresService.Scores == 0)
            {
                if (_scoresService.Scores != 0)
                {
                    int scoresChange = Mathf.Abs(_scoresService.Scores - _scores);
                    ShowAddScoresView(scoresChange);
                }

                _scores = _scoresService.Scores;
                Scores.text = _scores.ToString();
            }
        }

        private void ShowAddScoresView(int scores)
        {
            if (!_scoresSettings.AddScores || !AddScores || scores == 0)
                return;

            AddScoresView addScorePrefab = _scoresSettings.AddScoresData.ViewPrefab;
            if (addScorePrefab && AddScoresRoot)
            {
                AddScoresView addScoresView = Instantiate(addScorePrefab, AddScoresRoot, false);
                addScoresView.Initialize();
                addScoresView.Show(scores);
            }
        }
    }
}