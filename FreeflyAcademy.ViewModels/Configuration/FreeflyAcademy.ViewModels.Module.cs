using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.CreateSkydiver;
using FreeflyAcademy.ViewModels.Contracts.EditSkydiver;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using FreeflyAcademy.ViewModels.CreateSkydiver;
using FreeflyAcademy.ViewModels.EditSkydiver;
using FreeflyAcademy.ViewModels.ProgressSheet;
using FreeflyAcademy.ViewModels.SkydiverList;
using Ninject.Modules;

namespace FreeflyAcademy.ViewModels.Configuration
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InTransientScope();
            Bind<ISkydiverListViewModel>().To<SkydiverListViewModel>().InTransientScope();
            Bind<ISkydiverTileViewModel>().To<SkydiverTileViewModel>().InTransientScope();
            Bind<ISkydiverViewModel>().To<SkydiverViewModel>().InTransientScope();
            Bind<IProgressSheetViewModel>().To<ProgressSheetViewModel>().InTransientScope();
            Bind<ITrackProgressSheetViewModel>().To<TrackProgressSheetViewModel>().InTransientScope();
            Bind<IHeadUpProgressSheetViewModel>().To<HeadUpProgressSheetViewModel>().InTransientScope();
            Bind<IHeadDownProgressSheetViewModel>().To<HeadDownProgressSheetViewModel>().InTransientScope();
            Bind<ICoachTileViewModel>().To<CoachTileViewModel>().InTransientScope();
            Bind<IFileViewModel>().To<FileViewModel>().InTransientScope();

            Bind<IModalInfoViewModel>().To<ModalInfoViewModel>().InTransientScope();
            Bind<IValidateCoachModalViewModel>().To<ValidateCoachModalViewModel>().InTransientScope();
            Bind<ISelectCoachModalViewModel>().To<SelectCoachModalModalViewModel>().InTransientScope();
            Bind<ICreateSkydiverModalViewModel>().To<CreateSkydiverModalModalViewModel>().InTransientScope();
            Bind<IEditSkydiverModalViewModel>().To<EditSkydiverModalViewModel>().InTransientScope();
        }
    }
}