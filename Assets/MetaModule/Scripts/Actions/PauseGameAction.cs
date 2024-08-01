using Infrastructure.Attributes;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.ButtonActions
{
    [TopmostComponent(Order = 1)]
    public class PauseGameAction : ButtonAction
    {
        [SerializeField] private bool Pause;
        
        private GameLifecycleService _gameLifecycleService;

        public override void Action()
        {
            _gameLifecycleService.SetPause(Pause);
        }

        protected override void Initialize()
        {
            _gameLifecycleService = ServiceLocator.GetService<GameLifecycleService>();
        }
    }
}