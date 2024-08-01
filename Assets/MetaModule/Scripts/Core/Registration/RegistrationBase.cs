using System.Collections.Generic;
using Services.Core;
using UnityEngine;

namespace Infrastructure.Core
{
    public abstract class RegistrationBase : MonoBehaviour, IRegistration
    {
        [SerializeField] public List<MonoService> MonoServices;
        
        public abstract int Order { get; }

        public void Register(IServicesRegistrar registrar)
        {
            RegisterSerializedServices(registrar);
            RegisterServices(registrar);
        }

        protected abstract void RegisterServices(IServicesRegistrar registrar);

        private void RegisterSerializedServices(IServicesRegistrar registrar) =>
            MonoServices.ForEach(service => registrar.Register(service.GetType(), service));
    }
}