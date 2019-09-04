using FreeflyAcademy.Enums;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface IHeadUpProgressSheetViewModel : IModuleProgressSheetViewModel
    {
        AcquisitionLevel SecurityAltitude { get; set; }
        AcquisitionLevel SecurityReactivity { get; set; }
        AcquisitionLevel SecurityEase { get; set; }
        AcquisitionLevel SecurityHeading { get; set; }
        AcquisitionLevel Spin { get; set; }
        AcquisitionLevel Loop { get; set; }
        AcquisitionLevel Barrel { get; set; }
        AcquisitionLevel Level { get; set; }
        AcquisitionLevel Inertia { get; set; }
        AcquisitionLevel BreakAltitude { get; set; }
        AcquisitionLevel BreakSignal { get; set; }
        AcquisitionLevel BreakTrack { get; set; }
        AcquisitionLevel BreakEfficiency { get; set; }
    }
}
