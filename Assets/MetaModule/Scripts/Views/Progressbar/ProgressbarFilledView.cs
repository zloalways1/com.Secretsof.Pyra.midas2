using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class ProgressbarFilledView : ProgressbarBaseView
    {
        [SerializeField] private Image Target;

        protected override void AdjustVisual(float factor)
        {
            Target.fillAmount = factor;
        }
    }
}