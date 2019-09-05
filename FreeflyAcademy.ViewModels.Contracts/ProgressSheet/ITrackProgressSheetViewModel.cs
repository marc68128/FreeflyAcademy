using System;
using FreeflyAcademy.Enums;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface ITrackProgressSheetViewModel : IModuleProgressSheetViewModel
    {
        AcquisitionLevel SecurityAltitude { get; set; }
        AcquisitionLevel SecurityHeading { get; set; }
        AcquisitionLevel HalfBarrel { get; set; }
        AcquisitionLevel Barrel { get; set; }
        AcquisitionLevel SpeedUp { get; set; }
        AcquisitionLevel SlowDown { get; set; }
        AcquisitionLevel LevelControl { get; set; }
        AcquisitionLevel InertiaControl { get; set; }
        AcquisitionLevel Back { get; set; }
        AcquisitionLevel BackWithHeading { get; set; }
        AcquisitionLevel BreakSignal { get; set; }
        AcquisitionLevel BreakHeading { get; set; }
        AcquisitionLevel BreakEfficiency { get; set; }
        AcquisitionLevel BreakBarrelAndOpeningSignal { get; set; }


        bool Validated { get; set; }
        DateTime? ValidationDate { get; set; }
        string Coach { get; set; }
    }
}
