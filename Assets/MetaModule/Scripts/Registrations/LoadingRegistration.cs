using Infrastructure.Core;
using Infrastructure.Services;

namespace Registrations
{
    public class LoadingRegistration : RegistrationBase
    {
        public override int Order => 2;

        protected override void RegisterServices(IServicesRegistrar registrar)
        {
            registrar.Register<CurrentScreenService>();
            registrar.Register<ScoresService>();
            registrar.Register<GameLifecycleService>();
            registrar.Register<PlayerDataService>();
            registrar.Register<LevelsService>();
            registrar.Register<CoreFinisherService>();
            registrar.Register<TimerService>();
            registrar.Register<CoreStarterService>();
            registrar.Register<GameResultService>();
            registrar.Register<StartLevelService>();
            registrar.Register<ProgressionService>();
            registrar.Register<ExitGameService>();
        }
    }
}