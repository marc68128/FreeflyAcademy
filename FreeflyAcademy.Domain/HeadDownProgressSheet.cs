using FreeflyAcademy.Enums;

namespace FreeflyAcademy.Domain
{
    public class HeadDownProgressSheet : ModuleProgressSheet
    {
        public AcquisitionLevel SecurityAltitude { get; set; }
        public AcquisitionLevel SecurityReactivity { get; set; }
        public AcquisitionLevel SecurityEase { get; set; }
        public AcquisitionLevel SecurityHeading { get; set; }
        public AcquisitionLevel Spin { get; set; }
        public AcquisitionLevel Loop { get; set; }
        public AcquisitionLevel Barrel { get; set; }
        public AcquisitionLevel Transition { get; set; }
        public AcquisitionLevel Level { get; set; }
        public AcquisitionLevel Inertia { get; set; }
        public AcquisitionLevel BreakSignal { get; set; }
        public AcquisitionLevel Break180Track { get; set; }
        public AcquisitionLevel BreakBarrelAndOpeningSignal { get; set; }
    }
}