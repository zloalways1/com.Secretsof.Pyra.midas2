using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Core
{
    public class RegistrationsBinder : MonoBehaviour
    {
        [SerializeField] public List<RegistrationBase> Registrations;
        
        public void BindRegistrations(IRegistrationRegistrar registrar)
        {
            Registrations.ForEach(registrar.Register);
        }
    }
}