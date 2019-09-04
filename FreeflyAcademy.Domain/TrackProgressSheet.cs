using FreeflyAcademy.Enums;

namespace FreeflyAcademy.Domain
{
    public class TrackProgressSheet : ModuleProgressSheet
    {
        public AcquisitionLevel SecurityAltitude { get; set; }
        public AcquisitionLevel SecurityHeading { get; set; }
        public AcquisitionLevel HalfBarrel { get; set; }
        public AcquisitionLevel Barrel { get; set; }
        public AcquisitionLevel SpeedUp { get; set; }
        public AcquisitionLevel SlowDown { get; set; }
        public AcquisitionLevel LevelControl { get; set; }
        public AcquisitionLevel InertiaControl { get; set; }
        public AcquisitionLevel Back { get; set; }
        public AcquisitionLevel BackWithHeading { get; set; }
        public AcquisitionLevel BreakSignal { get; set; }
        public AcquisitionLevel BreakHeading { get; set; }
        public AcquisitionLevel BreakEfficiency { get; set; }
        public AcquisitionLevel BreakBarrelAndOpeningSignal { get; set; }
    }
}