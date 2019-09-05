using FreeflyAcademy.Services.Business;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.Services.Contracts.Technical;
using FreeflyAcademy.Services.Technical;
using Ninject.Modules;

namespace FreeflyAcademy.Services.Configuration
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISkydiverService>().To<SkydiverService>().InSingletonScope();
            Bind<IProgressSheetService>().To<ProgressSheetService>().InSingletonScope();
            Bind<ICoachService>().To<CoachService>().InSingletonScope();
            Bind<IFileCopierService>().To<FileCopierService>().InSingletonScope();
            Bind<IHashService>().To<HashService>().InSingletonScope();
        }
    }
}