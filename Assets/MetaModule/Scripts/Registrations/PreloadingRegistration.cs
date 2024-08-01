using Infrastructure.Core;
using Infrastructure.Services;

namespace Registrations
{
    public class PreloadingRegistration : RegistrationBase
    {
        public override int Order => 1;

        protected override void RegisterServices(IServicesRegistrar registrar)
        {
            registrar.Register<SaveLoadService>();
            registrar.Register<OptionsDataService>();
        }
    }
}