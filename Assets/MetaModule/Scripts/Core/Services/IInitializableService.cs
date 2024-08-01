using Infrastructure.Common;

namespace Infrastructure.Services
{
    public interface IInitializableService : IService, IInitializable
    {
    }
}