namespace Infrastructure.Services
{
    public class GameLifecycleService : IService
    {
        private bool _isActive;
        private bool _isPaused;

        public bool GameIsActive => _isActive && !_isPaused;

        public bool FieldLocked { get; private set; }

        public void StartGame()
        {
            SetPause(false);
            _isActive = true;
        }

        public void StopGame()
        {
            SetPause(true);
            _isActive = false;
        }

        public void SetPause(bool pause)
        {
            _isPaused = pause;
        }

        public void LockField()
        {
            FieldLocked = true;
        }

        public void UnlockField()
        {
            FieldLocked = false;
        }
    }
}