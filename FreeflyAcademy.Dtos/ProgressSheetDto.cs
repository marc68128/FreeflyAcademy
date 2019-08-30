using FreeflyAcademy.Enums;

namespace FreeflyAcademy.Dtos
{
    public class ProgressSheetDto 
    {
        //Module track
        public AcquisitionLevel TrackSecurityAltitude { get; set; }
        public AcquisitionLevel TrackSecurityHeading { get; set; }
        public AcquisitionLevel TrackHalfBarrel { get; set; }
        public AcquisitionLevel TrackBarrel { get; set; }
        public AcquisitionLevel TrackSpeedUp { get; set; }
        public AcquisitionLevel TrackSlowDown { get; set; }
        public AcquisitionLevel TrackLevelControl { get; set; }
        public AcquisitionLevel TrackInertiaControl { get; set; }
        public AcquisitionLevel TrackBack { get; set; }
        public AcquisitionLevel TrackBackWithHeading { get; set; }
        public AcquisitionLevel TrackBreakSignal { get; set; }
        public AcquisitionLevel TrackBreakHeading { get; set; }
        public AcquisitionLevel TrackBreakEfficiency { get; set; }
        public AcquisitionLevel TrackBreakBarrelAndOpeningSignal { get; set; }

        //Module tête en haut
        public AcquisitionLevel HeadUpSecurityAltitude { get; set; }
        public AcquisitionLevel HeadUpSecurityReactivity { get; set; }
        public AcquisitionLevel HeadUpSecurityEase { get; set; }
        public AcquisitionLevel HeadUpSecurityHeading { get; set; }
        public AcquisitionLevel HeadUpSpin { get; set; }
        public AcquisitionLevel HeadUpLoop { get; set; }
        public AcquisitionLevel HeadUpBarrel { get; set; }
        public AcquisitionLevel HeadUpLevel { get; set; }
        public AcquisitionLevel HeadUpInertia { get; set; }
        public AcquisitionLevel HeadUpBreakAltitude { get; set; }
        public AcquisitionLevel HeadUpBreakSignal { get; set; }
        public AcquisitionLevel HeadUpBreakTrack { get; set; }
        public AcquisitionLevel HeadUpBreakEfficiency { get; set; }

        //Module tête en bas
        public AcquisitionLevel HeadDownSecurityAltitude { get; set; }
        public AcquisitionLevel HeadDownSecurityReactivity { get; set; }
        public AcquisitionLevel HeadDownSecurityEase { get; set; }
        public AcquisitionLevel HeadDownSecurityHeading { get; set; }
        public AcquisitionLevel HeadDownSpin { get; set; }
        public AcquisitionLevel HeadDownLoop { get; set; }
        public AcquisitionLevel HeadDownBarrel { get; set; }
        public AcquisitionLevel HeadDownTransition { get; set; }
        public AcquisitionLevel HeadDownLevel { get; set; }
        public AcquisitionLevel HeadDownInertia { get; set; }
        public AcquisitionLevel HeadDownBreakSignal { get; set; }
        public AcquisitionLevel HeadDownBreak180Track { get; set; }
        public AcquisitionLevel HeadDownBreakBarrelAndOpeningSignal { get; set; }
    }
}
