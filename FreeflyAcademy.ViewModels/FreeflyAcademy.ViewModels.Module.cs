using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.CreateSkydiver;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using FreeflyAcademy.ViewModels.CreateSkydiver;
using FreeflyAcademy.ViewModels.ProgressSheet;
using FreeflyAcademy.ViewModels.SkydiverList;
using Ninject.Modules;

namespace FreeflyAcademy.ViewModels
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InTransientScope();
            Bind<ISkydiverListViewModel>().To<SkydiverListListViewModel>().InTransientScope();
            Bind<ISkydiverTileViewModel>().To<SkydiverTileViewModel>().InTransientScope();
            Bind<ISkydiverViewModel>().To<SkydiverViewModel>().InTransientScope();
            Bind<ICreateSkydiverViewModel>().To<CreateSkydiverViewModel>().InTransientScope();
            Bind<IProgressSheetViewModel>().To<ProgressSheetViewModel>().InTransientScope();
            Bind<ITrackProgressSheetViewModel>().To<TrackProgressSheetViewModel>().InTransientScope();
            Bind<IHeadUpProgressSheetViewModel>().To<HeadUpProgressSheetViewModel>().InTransientScope();
            Bind<IHeadDownProgressSheetViewModel>().To<HeadDownProgressSheetViewModel>().InTransientScope();
            Bind<ICoachTileViewModel>().To<CoachTileViewModel>().InTransientScope();

            Bind<IModalInfoViewModel>().To<ModalInfoViewModel>().InTransientScope();
            Bind<IValidateCoachModalViewModel>().To<ValidateCoachModalViewModel>().InTransientScope();
            Bind<ISelectCoachModalViewModel>().To<SelectCoachModalModalViewModel>().InTransientScope();
        }
    }
}