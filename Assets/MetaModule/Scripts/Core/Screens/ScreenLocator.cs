using System.Collections.Generic;
using Infrastructure.Common;
using Infrastructure.Screens.Internal;
using UnityEngine;

namespace Infrastructure.Screens
{
    public class ScreenLocator : ScreenLocatorBase, IInitializable
    {
        [SerializeField] public List<ScreenBase> Screens;

        public new static TScreen GetScreen<TScreen>()
            where TScreen : ScreenBase =>
            ScreenLocatorBase.GetScreen<TScreen>();

        public void Register() => Screens.ForEach(Register);

        public new void Initialize() => base.Initialize();
    }
}