using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class OptionsDataService : IInitializableService
    {
        private SaveLoadService _saveLoadService = ServiceLocator.GetService<SaveLoadService>();
        
        public OptionsData OptionsData { get; private set; }

        public void Initialize()
        {
            OptionsData = _saveLoadService.LoadOrCreateOptionsData();
        }

        public void Save()
        {
            _saveLoadService.SaveOptionsData(OptionsData);
        }
    }
}