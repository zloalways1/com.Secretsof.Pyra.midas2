using Infrastructure.Core;
using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Infrastructure.Views
{
    public class FinishLevelView : MetaView
    {
        [SerializeField] private TMP_Text Level;
        
        private GameResultService _gameResultService;

        public override void Initialize()
        {
            _gameResultService = ServiceLocator.GetService<GameResultService>();
        }

        public override void Show()
        {
            Level.text = _gameResultService.GameResultData.CurrentLevel.ToString();
        }
    }
}