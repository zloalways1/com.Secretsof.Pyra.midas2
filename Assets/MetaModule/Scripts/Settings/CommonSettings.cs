using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "CommonSettings")]
    public class CommonSettings : SettingsBase
    {
        [SerializeField] public int InitialLevelTime;
        [SerializeField] public bool AlwaysThreeStars;
        [SerializeField] public int Time3Stars;
        [SerializeField] public int Time2Stars;
        [SerializeField] public bool TimerFromZero;
        [SerializeField] public int LevelsCount;
    }
}