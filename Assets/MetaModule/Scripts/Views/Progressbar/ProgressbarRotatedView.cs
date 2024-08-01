using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Views
{
    public class ProgressbarRotatedView : ProgressbarBaseView
    {
        [SerializeField] private Transform Target;
        [SerializeField] private float CycleTime;
        [SerializeField] private Ease Ease;

        public override void Hide()
        {
            if (Target)
                Target.DOKill();
        }

        protected override void AdjustVisual(float factor)
        {
            if (Target)
            {
                DOTween.To(
                        () => Target.rotation.eulerAngles,
                        value => Target.eulerAngles = value,
                        new Vector3(0, 0, -360),
                        CycleTime
                    ).SetLoops(-1, LoopType.Restart)
                    .SetEase(Ease);
            }
        }
    }
}