using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "LoadingSettings")]
    public class LoadingSettings : SettingsBase
    {
        [SerializeField] public float LoadingTime;
    }
}