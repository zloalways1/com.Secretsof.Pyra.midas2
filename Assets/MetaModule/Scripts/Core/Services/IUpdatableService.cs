namespace Infrastructure.Services
{
    public interface IUpdatableService : IService
    {
        public void UpdateService(float deltaTime);
    }
}