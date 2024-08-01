using DG.Tweening;
using Infrastructure.Core;
using Infrastructure.Services;
using Infrastructure.Settings;
using TMPro;
using UnityEngine;

namespace Infrastructure.Views
{
    public class AddScoresView : MetaView<int>
    {
        [SerializeField] private TMP_Text Text;
        [SerializeField] private RectTransform Transform;
        
        private ScoresSettings _scoresSettings;

        public override void Initialize()
        {
            _scoresSettings = ServiceLocator.GetService<ConfigurationService>().GetSettings<ScoresSettings>();
        }

        public override void Show(int scores)
        {
            Text.text = $"+{scores}";
            AnimateAddScores();
        }

        private void AnimateAddScores()
        {
            DOTween
                .To(
                    () => Transform.anchoredPosition,
                    value => Transform.anchoredPosition = value,
                    Transform.anchoredPosition + _scoresSettings.AddScoresData.MoveOffset,
                    _scoresSettings.AddScoresData.MoveTime)
                .SetEase(_scoresSettings.AddScoresData.MoveEase);

            Transform
                .DOScale(
                    Vector3.one * _scoresSettings.AddScoresData.Scale, 
                    _scoresSettings.AddScoresData.ScaleTime)
                .SetEase(_scoresSettings.AddScoresData.ScaleEase)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}