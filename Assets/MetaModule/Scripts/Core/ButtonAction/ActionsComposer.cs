using System.Collections.Generic;
using System.Linq;
using Infrastructure.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.ButtonActions
{
    [RequireComponent(typeof(Button))]
    [TopmostComponent(Order = 100)]
    public class ActionsComposer : MonoBehaviour
    {
        private List<ButtonAction> _buttonActions = new List<ButtonAction>();
        private Button _button;

        public void Register(ButtonAction buttonAction)
        {
            _buttonActions.Add(buttonAction);
        }

        private void Awake()
        {
            InitializeButton();
        }

        private void InitializeButton()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OrderedInvokeButtonActions);
        }

        private void OrderedInvokeButtonActions()
        {
            _buttonActions
                .OrderBy(buttonAction => buttonAction.Order)
                .ToList()
                .ForEach(buttonAction => buttonAction.Action());
        }
    }
}