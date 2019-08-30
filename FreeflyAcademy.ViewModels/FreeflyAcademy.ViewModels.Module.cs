using FreeflyAcademy.ViewModels.Contracts;
using Ninject.Modules;

namespace FreeflyAcademy.ViewModels
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InTransientScope();
            Bind<ISkydiversViewModel>().To<SkydiversViewModel>().InTransientScope();
            Bind<ISkydiverTileViewModel>().To<SkydiverTileViewModel>().InTransientScope();
            Bind<ISkydiverViewModel>().To<SkydiverViewModel>().InTransientScope();
            Bind<ICreateSkydiverViewModel>().To<CreateSkydiverViewModel>().InTransientScope();
            Bind<IProgressSheetViewModel>().To<ProgressSheetViewModel>().InTransientScope();
            Bind<ITrackProgressSheetViewModel>().To<TrackProgressSheetViewModel>().InTransientScope();
        }
    }
}