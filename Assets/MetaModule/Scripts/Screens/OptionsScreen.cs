using Infrastructure.Views;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class OptionsScreen : ScreenBase, IInitializableScreen
    {
        [SerializeField] private OptionsView OptionsView;

        public void Initialize()
        {
            InitViews();
        }

        protected override void OnShow()
        {
            ShowViews();
        }

        protected override void OnHide()
        {
            HideViews();
        }

        private void InitViews()
        {
            if (OptionsView)
                OptionsView.Initialize();
        }

        private void ShowViews()
        {
            if (OptionsView)
                OptionsView.Show();
        }

        private void HideViews()
        {
            if (OptionsView)
                OptionsView.Hide();
        }
    }
}