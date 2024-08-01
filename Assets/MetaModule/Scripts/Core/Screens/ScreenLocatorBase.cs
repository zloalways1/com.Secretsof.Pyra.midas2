using Infrastructure.Common;
using UnityEngine;

namespace Infrastructure.Screens.Internal
{
    public class ScreenLocatorBase : MonoBehaviour
    {
        private static TypedDictionary<ScreenBase> _screens = new TypedDictionary<ScreenBase>();
        private static TypedHashSet<IInitializableScreen> _initializableScreens = new TypedHashSet<IInitializableScreen>();

        protected void Register<TScreenType>(TScreenType screen) where TScreenType : ScreenBase
        {
            if (!_screens.Has<TScreenType>())
            {
                _screens.Register(screen.GetType(), screen);
                
                screen.InjectScreenService();
                
                if (screen is IInitializableScreen initializableScreen)
                    _initializableScreens.Add(initializableScreen);
            }
        }

        protected static TScreen GetScreen<TScreen>() 
            where TScreen : ScreenBase => 
            _screens.Get<TScreen>();

        protected void Initialize() => 
            _initializableScreens.ForEach(screen => screen.Initialize());
    }
}