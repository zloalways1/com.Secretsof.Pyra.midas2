using Coffee.UIEffects;
using Services.Core;
using UnityEngine;

namespace Game.Services
{
    public class BlurService : MonoService
    {
        [SerializeField] public UIEffect BlurEffect;

        public void EnableBlur()
        {
            if (BlurEffect)
                BlurEffect.blurFactor = 1;
        }
        
        public void DisableBlur()
        {
            if (BlurEffect)
                BlurEffect.blurFactor = 0;
        }
    }
}