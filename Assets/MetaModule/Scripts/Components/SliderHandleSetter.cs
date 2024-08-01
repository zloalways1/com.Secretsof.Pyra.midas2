using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Components
{
    public class SliderHandleSetter : MonoBehaviour
    {
        public Slider Slider;
        public Image Handle;
        public Sprite EnabledHandleSprite;
        public Color EnabledColor;
        public Sprite DisabledHandleSprite;
        public Color DisabledColor;
        public bool ChangeSprites;
        public bool ChangeColors;

        private void Awake()
        {
            Slider.onValueChanged.AddListener(OnSliderValueChanged);
            OnSliderValueChanged(Slider.value);
        }

        private void OnSliderValueChanged(float value)
        {
            if (ChangeSprites)
                Handle.sprite =
                    value == 0
                        ? DisabledHandleSprite
                        : EnabledHandleSprite;

            if (ChangeColors)
                Handle.color =
                    value == 0
                        ? DisabledColor
                        : EnabledColor;
        }
    }
}