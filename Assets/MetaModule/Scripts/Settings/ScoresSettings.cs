using Infrastructure.Core;
using Infrastructure.Data;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "ScoresSettings")]
    public class ScoresSettings : SettingsBase
    {
        [SerializeField] public int ScoresForMatch;
        [SerializeField] public int ScoresToWin;
        [SerializeField] public bool WinByScores;

        [SerializeField] public bool AddScores;
        [SerializeField] public AddScoresData AddScoresData;
    }
}