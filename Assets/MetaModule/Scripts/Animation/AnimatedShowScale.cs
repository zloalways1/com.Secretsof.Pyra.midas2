using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public class AnimatedShowScale : MonoBehaviour
    {
        public float InitialScale;
        public float TargetScale;
        public float Time;
        public Ease Ease;
        
        public void Show()
        {
            transform.localScale = Vector3.one * InitialScale; 
            transform.DOScale(TargetScale, Time).SetEase(Ease);
        }
    }
}