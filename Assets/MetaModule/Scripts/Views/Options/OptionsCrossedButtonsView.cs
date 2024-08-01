using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsCrossedButtonsView : OptionsView
    {
        [SerializeField] private Button SfxButton;
        [SerializeField] private Image SfxCross;
        [SerializeField] private Button MusicButton;
        [SerializeField] private Image MusicCross;

        public override void UpdateView()
        {
            SfxCross.enabled = !_soundService.SfxEnabled;
            MusicCross.enabled = !_soundService.MusicEnabled;
        }

        protected override void Subscribe()
        {
            SfxButton.onClick.AddListener(SwitchEnableSfx);
            MusicButton.onClick.AddListener(SwitchEnableMusic);
        }

        private void SwitchEnableSfx()
        {
            _soundService.SwitchSfxEnabled();
            UpdateView();
        }

        private void SwitchEnableMusic()
        {
            _soundService.SwitchMusicEnabled();
            UpdateView();
        }
    }
}