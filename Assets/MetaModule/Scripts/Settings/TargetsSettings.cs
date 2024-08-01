using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "TargetsSettings")]
    public class TargetsSettings : SettingsBase
    {
        [SerializeField] public bool UseTargets;
        [SerializeField] public int TargetsTypesCount;
        [SerializeField] public int InitialTargetsCount;
        [SerializeField] public float DelayBeforeWin;
        [SerializeField] public AudioClip TargetCollectedSound;
        [SerializeField] public int ProgressiveTargetsCount;
    }
}