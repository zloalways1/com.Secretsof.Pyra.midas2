using Infrastructure.Screens;

namespace Infrastructure.Services
{
    public class StartLevelService : IInitializableService
    {
        private LevelsService _levelsService;
        private CoreStarterService _coreStarterService;
        private LevelsScreen _levelsScreen;

        public void Initialize()
        {
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _levelsScreen = ScreenLocator.GetScreen<LevelsScreen>();
            _coreStarterService = ServiceLocator.GetService<CoreStarterService>();
        }

        public void StartLevelIfUnlocked(int level)
        {
            if (_levelsService.IsLevelUnlocked(level))
            {
                _levelsScreen.Hide();
                
                _levelsService.SetCurrentLevel(level);
                
                _coreStarterService.StartCore();
            }
        }
    }
}