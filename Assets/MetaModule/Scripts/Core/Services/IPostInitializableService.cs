namespace Infrastructure.Services
{
    public interface IPostInitializableService : IService
    {
        public void PostInitialize();
    }
}