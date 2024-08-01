using System;
using Infrastructure.Common;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Services.Internal
{
    public class ServiceLocatorBase : MonoBehaviour
    {
        private static TypedDictionary<IService> _services = new TypedDictionary<IService>();
        private static TypedHashSet<IUpdatableService> _updatableServices = new TypedHashSet<IUpdatableService>();
        private static TypedHashSet<IInitializableService> _initializableServices = new TypedHashSet<IInitializableService>();
        private static TypedHashSet<IPostInitializableService> _postInitializableServices = new TypedHashSet<IPostInitializableService>();

        protected static TService GetService<TService>() where TService : class, IService
        {
            return _services.Get<TService>();
        }

        protected TService Register<TService>() where TService : class, IService, new()
        {
            if (!_services.Has<TService>())
            {
                TService instance = _services.Create<TService>();
                RegisterInterfaces(instance);

                return instance;
            }

            return GetService<TService>();
        }

        protected void Register<TInterface, TService>(TService instance)
            where TInterface : IService
            where TService : MonoService, TInterface
        {
            
            Register(typeof(TService), instance);
            RegisterInterface<TInterface, TService>(instance);
        }
        
        protected void Register<TInterface, TService>()
            where TInterface : IService
            where TService : class, TInterface, new()
        {
            TService instance = Register<TService>();
            RegisterInterface<TInterface, TService>(instance);
        }

        protected void Register(Type type, MonoService service)
        {
            if (!_services.Has(type))
            {
                _services.Register(type, service);
                RegisterInterfaces(service);
            }
        }

        protected void Initialize()
        {
            _initializableServices.ForEach( service => service.Initialize());
        }

        protected void PostInitialize()
        {
            _postInitializableServices.ForEach( service => service.PostInitialize());
        }

        protected void UpdateServices(float dt)
        {
            _updatableServices.ForEach( service => service.UpdateService(dt));
        }

        private void RegisterInterface<TInterface, TService>(TService instance)
            where TInterface : IService
            where TService : class, TInterface
        {
            if (!_services.Has<TInterface>()) 
                _services.Register(typeof(TInterface), instance);
        }

        private void RegisterInterfaces(IService service)
        {
            RegisterServiceInterface(service, _updatableServices);
            RegisterServiceInterface(service, _initializableServices);
            RegisterServiceInterface(service, _postInitializableServices);
        }

        private void RegisterServiceInterface<TInterface>(IService service, TypedHashSet<TInterface> target) 
            where TInterface : class, IService
        {
            if (service is TInterface @interface)
                target.Add(@interface);
        }
    }
}