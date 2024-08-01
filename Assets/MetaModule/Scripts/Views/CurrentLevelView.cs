using Infrastructure.Core;
using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Infrastructure.Views
{
    public class CurrentLevelView : MetaView
    {
        [SerializeField] private TMP_Text Level;
        
        private LevelsService _levelsService;

        public override void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
        }

        public override void Show()
        {
            Level.text = _levelsService.CurrentLevel.ToString();
        }
    }
}