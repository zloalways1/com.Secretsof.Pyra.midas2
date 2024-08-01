using Infrastructure.Services;

namespace Core.Game
{
    public interface IGameService : IInitializableService
    {
        public void CreateField();
        public void ClearField();
    }
}