using System;
using Infrastructure.Services;
using Services.Core;

namespace Infrastructure.Core
{
    public interface IServicesRegistrar
    {
        public void Register<TService>() 
            where TService : class, IService, new();

        public void Register<TInterface, TService>()
            where TInterface : IService 
            where TService : class, TInterface, new();

        public void Register(Type type, MonoService service);

        public void Register<TInterface, TService>(TService instance)
            where TInterface : IService 
            where TService : MonoService, TInterface;
    }
}