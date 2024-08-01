using System;
using Infrastructure.Settings;

namespace Infrastructure.Services
{
    public class ScoresService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private CoreFinisherService _coreFinisher;
        private ScoresSettings _scoresSettings;

        public int Scores { get; private set; }
        
        public int MaxScores { get; private set; }
        
        public event Action<int> ScoresAdded;

        public void Initialize()
        {
            _coreFinisher = ServiceLocator.GetService<CoreFinisherService>();
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _scoresSettings = _configurationService.GetSettings<ScoresSettings>();
        }

        public void ResetScores()
        {
            Scores = 0;
            MaxScores = _scoresSettings.ScoresToWin;
        }

        public void AddScores(int matchesCount)
        {
            int scores = matchesCount * _scoresSettings.ScoresForMatch;
            Scores += scores;
            
            ScoresAdded?.Invoke(scores);

            if (Scores >= MaxScores)
                WinGameByScores();
        }

        private void WinGameByScores()
        {
            if (_scoresSettings.WinByScores)
                _coreFinisher.WinGame();
        }
    }
}