using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class OptionsButtonsView : OptionsView
    {
        [SerializeField] private Button MusicOnButton;
        [SerializeField] private Button MusicOffButton;
        [SerializeField] private Button SfxOnButton;
        [SerializeField] private Button SfxOffButton;

        protected override void Subscribe()
        {
            SubscribeButtons();
        }

        private void SubscribeButtons()
        {
            if (MusicOnButton)
                MusicOnButton.onClick.AddListener(() => _soundService.SetMusicEnabled(true));
            
            if (MusicOffButton)
                MusicOffButton.onClick.AddListener(() => _soundService.SetMusicEnabled(false));
            
            if (SfxOnButton)
                SfxOnButton.onClick.AddListener(() => _soundService.SetSfxEnabled(true));
            
            if (SfxOffButton)
                SfxOffButton.onClick.AddListener(() => _soundService.SetSfxEnabled(false));
        }
    }
}