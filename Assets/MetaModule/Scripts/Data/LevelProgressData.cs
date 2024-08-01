using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Data
{
    [Serializable]
    public class LevelProgress
    {
        [SerializeField]
        public List<LevelProgressData> LevelsProgress;
    }
    
    [Serializable]
    public class LevelProgressData
    {
        [SerializeField] public int Level;
        [SerializeField] public int Stars;

        public LevelProgressData(int level, int stars)
        {
            Level = level;
            Stars = stars;
        }
    }
}