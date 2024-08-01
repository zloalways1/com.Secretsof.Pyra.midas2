using System;
using System.Collections.Generic;
using Core.Services;
using Infrastructure.Common;
using Infrastructure.Services;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Core
{
    public abstract class GameFactory<T> : MonoService, IInitializableService where T : IConfigurationService
    {
        [SerializeField] private List<GameViewBase> Prefabs;
        
        private IConfigurationService _configurationService;

        public virtual void Initialize()
        {
            _configurationService = ServiceLocator.GetService<IConfigurationService>();
        }

        public TView CreateView<TView>(Transform parent) where TView : GameViewBase
        {
            foreach (var gameView in Prefabs)
            {
                if (gameView is TView view)
                {
                    TView instance = Instantiate(view, parent, false);
                    instance.Construct(_configurationService.Configuration);
                    
                    return instance;
                }
            }

            throw new ArgumentException($"Missed prefab for type: {nameof(TView)}");
        }
    }
}