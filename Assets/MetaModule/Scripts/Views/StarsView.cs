using System.Collections.Generic;
using Animation;
using Infrastructure.Core;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Views
{
    public class StarsView : MetaView
    {
        [SerializeField] public List<AnimatedShowScale> Stars;
        [SerializeField] public List<GameObject> ProgressStars;
        
        private GameResultService _gameResultService;

        public override void Initialize()
        {
            _gameResultService = ServiceLocator.GetService<GameResultService>();
        }

        public override void Show()
        {
            ShowAnimatedStars();
            ShowProgressStars();
        }

        private void ShowAnimatedStars()
        {
            if (Stars != null && Stars.Count > 0)
                Stars.ForEach(star => star.Show());
        }

        private void ShowProgressStars()
        {
            if (ProgressStars != null && ProgressStars.Count > 0)
            {
                ProgressStars.ForEach(star => 
                    star.SetActive(ProgressStars.IndexOf(star) < _gameResultService.GameResultData.Stars));
            }
        }
    }
}