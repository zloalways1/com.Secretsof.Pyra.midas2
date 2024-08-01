using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class CurrentScreenService : IService
    {
        private ScreenBase _previousScreen;
        private ScreenBase _currentScreen;

        public void UpdateCurrentScreen(ScreenBase currentScreen)
        {
            _previousScreen = _currentScreen;
            _currentScreen = currentScreen;
        }

        public void ShowCurrentScreen() => _currentScreen.Show();
        
        public void HideCurrentScreen() => _currentScreen.Hide();

        public void ShowPreviousScreen() => _previousScreen.Show();

        public void HidePreviousScreen() => _previousScreen.Hide();
    }
}