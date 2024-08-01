using Infrastructure.Core;
using UnityEngine;

namespace Infrastructure.Settings
{
    [CreateAssetMenu(fileName = "SoundSettings")]
    public class SoundSettings : SettingsBase
    {
        [SerializeField] public AudioClip BackMusic;
        
        [Space]
        [SerializeField] public AudioClip Click;
        [SerializeField] public AudioClip WinGame;
        [SerializeField] public AudioClip LoseGame;
    }
}