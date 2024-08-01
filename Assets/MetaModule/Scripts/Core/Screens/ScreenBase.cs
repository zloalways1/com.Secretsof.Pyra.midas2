using Infrastructure.Attributes;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Screens
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    [TopmostComponent]
    public abstract class ScreenBase : MonoBehaviour
    {
        private Canvas _canvas;
        private CurrentScreenService _currentScreenService;

        public void InjectScreenService()
        {
            _currentScreenService = ServiceLocator.GetService<CurrentScreenService>();
        }

        public void Show()
        {
            UpdateServiceScreens();
            EnableCanvas();
            OnShow();
        }

        public void Hide()
        {
            DisableCanvas();
            OnHide();
        }

        protected virtual void OnShow()
        {
        }

        protected virtual void OnHide()
        {
        }

        private void UpdateServiceScreens()
        {
            _currentScreenService.UpdateCurrentScreen(this);
        }

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            DisableCanvas();
        }

        private void EnableCanvas() => _canvas.enabled = true;

        private void DisableCanvas() => _canvas.enabled = false;
    }
}