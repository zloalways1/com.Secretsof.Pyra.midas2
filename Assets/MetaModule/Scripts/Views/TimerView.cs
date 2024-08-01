using System;
using Infrastructure.Core;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.ButtonActions
{
    public class TimerView : MetaView
    {
        [SerializeField] private TMP_Text TimerText;
        [SerializeField] private Image FilledImage;
        [SerializeField] private RectTransform StretchedImage;
        [SerializeField] private float MinSize;
        [SerializeField] private float MaxSize;
        
        private TimerService _timerService;

        public override void Initialize()
        {
            _timerService = ServiceLocator.GetService<TimerService>();
        }

        public override void UpdateView()
        {
            if (TimerText)
                SetTimerText(_timerService.CurrentTime);
        }

        public override void Show()
        {
            UpdateView();
        }

        public void UpdateTimer()
        {
            if (_timerService is { Enabled: true })
            {
                float timeLeftPercent = _timerService.TimeLeftPercent;
                
                if (FilledImage)
                    FilledImage.fillAmount = timeLeftPercent;
                
                if (StretchedImage)
                    StretchedImage.sizeDelta = new Vector2(
                        MinSize + ((MaxSize - MinSize) * timeLeftPercent),
                        StretchedImage.sizeDelta.y);
                
                UpdateView();
            }
        }

        public void ResetTimer()
        {
            if (FilledImage)
                FilledImage.fillAmount = 1;
            
            if (StretchedImage)
                StretchedImage.sizeDelta = new Vector2(MaxSize, StretchedImage.sizeDelta.y);
        }

        private void SetTimerText(float timeInSeconds)
        {
            TimeSpan ts = TimeSpan.FromSeconds(timeInSeconds);
            TimerText.text = $"{(int)ts.TotalMinutes:00}:{ts.Seconds:00}";
        }
    }
}