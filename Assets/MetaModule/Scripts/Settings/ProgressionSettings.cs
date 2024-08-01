using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "ProgressionSettings")]
    public class ProgressionSettings : SettingsBase
    {
        public int WinScores;
        public int ProgressiveWinScores;
        public int LevelTime;
        public int ProgressiveLevelTime;
        public int TargetsCount;
        public int ProgressiveTargetsCount;
    }
}