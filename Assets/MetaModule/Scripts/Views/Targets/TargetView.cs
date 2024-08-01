using Infrastructure.Core;
using Infrastructure.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Views
{
    public class TargetView : MetaView<TargetData>
    {
        [SerializeField] private Image Image;
        [SerializeField] private TMP_Text Counter;
        
        private TargetData _targetData;

        public Sprite TargetType => _targetData.Type;

        public override void Show(TargetData targetData)
        {
            _targetData = targetData;
            UpdateView();
        }

        public override void UpdateView()
        {
            Image.sprite = _targetData.Type;
            Counter.text = _targetData.Count.ToString();
        }
    }
}