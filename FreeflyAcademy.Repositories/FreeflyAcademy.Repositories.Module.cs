using FreeflyAcademy.Repositories.Contracts;
using Ninject.Modules;

namespace FreeflyAcademy.Repositories
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISkydiverRepository>().To<SkydiverRepository>().InSingletonScope();
            Bind<IProgressSheetRepository>().To<ProgressSheetRepository>().InSingletonScope();
            Bind<ICoachRepository>().To<CoachRepository>().InSingletonScope();
        }
    }
}