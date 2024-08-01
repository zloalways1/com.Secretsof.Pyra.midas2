namespace Infrastructure.Core
{
    public interface IRegistration
    {
        public void Register(IServicesRegistrar registrar);
    }
}