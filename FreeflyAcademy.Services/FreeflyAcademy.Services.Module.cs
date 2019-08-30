using FreeflyAcademy.Services.Contracts;
using Ninject.Modules;

namespace FreeflyAcademy.Services
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISkydiverService>().To<SkydiverService>().InSingletonScope();
            Bind<IProgressSheetService>().To<ProgressSheetService>().InSingletonScope();
            Bind<ICoachService>().To<CoachService>().InSingletonScope();
        }
    }
}