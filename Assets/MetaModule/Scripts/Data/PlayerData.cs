using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Data
{
    [Serializable]
    public class PlayerData
    {
        public int CurrentLevel { get; private set; }

        [SerializeField]
        public LevelProgress LevelProgress = new LevelProgress();
        
        public event Action OnUpdate;

        public PlayerData(int currentLevel)
        {
            CurrentLevel = currentLevel;
            LevelProgress.LevelsProgress = new List<LevelProgressData>();
            SetCurrentLevelProgress(0);
            UpdateData();
        }

        public void SetCurrentLevel(int level)
        {
            CurrentLevel = level;
            UpdateData();
        }
        
        public void SetLevelsProgress(LevelProgress levelProgress)
        {
            LevelProgress = levelProgress;
            UpdateData();
        }

        public int GetLevelProgress(int level)
        {
            LevelProgressData levelData = LevelProgress.LevelsProgress.FirstOrDefault(levelData => levelData.Level == level);
            return levelData?.Stars ?? 0;
        }

        public int MaxUnlockedLevel()
        {
            int maxLevelWithProgress = LevelProgress.LevelsProgress
                .Where(levelData => levelData.Stars > 0)
                .Select(levelData => levelData.Level)
                .DefaultIfEmpty(0)
                .Max();
            
            return maxLevelWithProgress + 1;
        }

        public void SetNextCurrentLevel()
        {
            CurrentLevel++;
            UpdateData();
        }

        public void SetCurrentLevelProgress(int stars)
        {
            LevelProgressData levelData = LevelProgress.LevelsProgress.FirstOrDefault(levelData => levelData.Level == CurrentLevel);
            if (levelData != null)
            {
                if (levelData.Stars < stars)
                    levelData.Stars = stars;
            }
            else
            {
                LevelProgressData newLevelData = new LevelProgressData(CurrentLevel, stars);
                LevelProgress.LevelsProgress.Add(newLevelData);
            }
        }

        private void UpdateData()
        {
            OnUpdate?.Invoke();
        }
    }
}