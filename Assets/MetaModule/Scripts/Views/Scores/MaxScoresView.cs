using TMPro;
using UnityEngine;

namespace Infrastructure.Views
{
    public class MaxScoresView : ScoresView
    {
        [SerializeField] private TMP_Text MaxScores;

        private int _maxScores;

        public override void UpdateView()
        {
            base.UpdateView();
            
            if (_maxScores != _scoresService.MaxScores)
            {
                _maxScores = _scoresService.MaxScores;
                MaxScores.text = _maxScores.ToString();
            }
        }
    }
}