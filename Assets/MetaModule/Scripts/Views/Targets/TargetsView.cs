using System.Collections.Generic;
using System.Linq;
using Infrastructure.Core;
using Infrastructure.Data;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Views
{
    public class TargetsView : MetaView
    {
        [SerializeField] private Transform Container;
        [SerializeField] private TargetView TargetViewPrefab;

        private List<TargetView> _createdTargets = new List<TargetView>();

        private ITargetsService _targetsService;
        
        public override void Initialize()
        {
            _targetsService = ServiceLocator.GetService<ITargetsService>();
            if (_targetsService != null)
                _targetsService.TargetUpdated += OnTargetUpdated;
        }

        public override void Show()
        {
            if (_targetsService == null)
            {
                Hide();
                return;
            }
            
            Clear();
            Create();
        }

        private void OnTargetUpdated(Sprite type)
        {
            TargetView targetView = _createdTargets.FirstOrDefault(target => target.TargetType == type);
            if (targetView) 
                targetView.UpdateView();
        }

        private void Create()
        {
            foreach (TargetData targetData in _targetsService.Targets)
            {
                TargetView targetView = Instantiate(TargetViewPrefab, Container, false);
                targetView.Initialize();
                targetView.Show(targetData);
                
                _createdTargets.Add(targetView);
            }
        }

        private void Clear()
        {
            _createdTargets.ForEach(target => Destroy(target.gameObject));
            _createdTargets.Clear();
        }
    }
}