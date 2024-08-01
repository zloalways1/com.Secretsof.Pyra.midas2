using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Infrastructure.Extensions
{
    public static class DoTweenExtensions
    {
        public static TweenerCore<Vector2, Vector2, VectorOptions> AnimateAnchoredPosition(this RectTransform target, Vector2 targetValue, float time, Ease ease)
        {
            return DOTween
                .To(
                    () => target.anchoredPosition,
                    value => target.anchoredPosition = value,
                    targetValue, time)
                .SetEase(ease);
        }
    }
}