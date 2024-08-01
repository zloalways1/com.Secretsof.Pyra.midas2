using System;
using Infrastructure.Common;
using Infrastructure.Core;
using Infrastructure.Services.Internal;
using Services.Core;

namespace Infrastructure.Services
{
    public class ServiceLocator : ServiceLocatorBase, IInitializable, IServicesRegistrar, IRegistrationRegistrar
    {
        public new void Initialize() => base.Initialize();
        
        public new void PostInitialize() => base.PostInitialize();
        
        public new void UpdateServices(float dt) => base.UpdateServices(dt);

        public void Register(IRegistration registration) => registration.Register(this);

        public new static TService GetService<TService>()
            where TService : class, IService =>
            ServiceLocatorBase.GetService<TService>();

        public new void Register<TService>() 
            where TService : class, IService, new() => 
            base.Register<TService>();

        public new void Register<TInterface, TService>()
            where TInterface : IService 
            where TService : class, TInterface, new() =>
            base.Register<TInterface, TService>();

        public new void Register(Type type, MonoService service) => 
            base.Register(type, service);

        public new void Register<TInterface, TService>(TService instance) 
            where TInterface : IService 
            where TService : MonoService, TInterface =>
            base.Register<TInterface, TService>(instance);
    }
}