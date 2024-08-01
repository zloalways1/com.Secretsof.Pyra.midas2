using Infrastructure.Attributes;
using Infrastructure.ButtonActions;
using UnityEngine;
using UnityEngine.UI;

namespace Core.MetaModule.Scripts.Buttons
{
    [TopmostComponent(Order = 0)]
    [RequireComponent(typeof(PlayClickSoundAction))]
    public abstract class ButtonBase : MonoBehaviour
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
            Graphic graphic = GetComponent<Graphic>();
            if (graphic)
                graphic.raycastTarget = true;
        }
#endif
    }
}