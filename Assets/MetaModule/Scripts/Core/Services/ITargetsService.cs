using System;
using System.Collections.Generic;
using Infrastructure.Data;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ITargetsService : IInitializableService
    {
        public void CreateTargets();
        
        public void CollectTarget(Sprite type);
        
        public bool Enabled { get; }

        public event Action<Sprite> TargetUpdated;
        
        public event Action TargetsCollected;

        public List<TargetData> Targets { get; }
        
        public bool AllTargetsCollected { get; }

        public float DelayBeforeWin { get; }
    }
}