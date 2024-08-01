using Infrastructure.Core;
using Infrastructure.Services;

namespace Core.Services
{
    public interface IConfigurationService : IService
    {
        public ConfigurationProxy Configuration { get; }
    }
}