using FreeflyAcademy.Enums;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface IHeadDownProgressSheetViewModel : IBaseViewModel
    {
        AcquisitionLevel SecurityAltitude { get; set; }
        AcquisitionLevel SecurityReactivity { get; set; }
        AcquisitionLevel SecurityEase { get; set; }
        AcquisitionLevel SecurityHeading { get; set; }
        AcquisitionLevel Spin { get; set; }
        AcquisitionLevel Loop { get; set; }
        AcquisitionLevel Barrel { get; set; }
        AcquisitionLevel Transition { get; set; }
        AcquisitionLevel Level { get; set; }
        AcquisitionLevel Inertia { get; set; }
        AcquisitionLevel BreakSignal { get; set; }
        AcquisitionLevel Break180Track { get; set; }
        AcquisitionLevel BreakBarrelAndOpeningSignal { get; set; }
    }
}
