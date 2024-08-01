using System;

namespace Infrastructure.Data
{
    [Serializable]
    public class OptionsData
    {
        public float SfxVolume;
        public float MusicVolume;
        public bool VibrationEnabled;

        public OptionsData(float musicVolume, float sfxVolume, bool vibration)
        {
            MusicVolume = musicVolume;
            SfxVolume = sfxVolume;
            VibrationEnabled = vibration;
        }
    }
}