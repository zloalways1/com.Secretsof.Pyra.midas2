using UnityEngine;

namespace Infrastructure.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class ProgressbarStretchedView : ProgressbarBaseView
    {
        [SerializeField] private RectTransform Target;
        [SerializeField] private int MinSize;
        [SerializeField] private int MaxSize;

        protected override void AdjustVisual(float factor)
        {
            float sizeX = MinSize + (MaxSize - MinSize) * factor;
            Target.sizeDelta = new Vector2(sizeX, Target.sizeDelta.y);
        }
    }
}