using Infrastructure.ButtonActions;
using UnityEngine;

namespace Core.MetaModule.Scripts.Buttons
{
    [RequireComponent(typeof(OpenPreviousScreenAction))]
    [RequireComponent(typeof(PauseGameAction))]
    public class BackButton : ButtonBase
    {
    }
}