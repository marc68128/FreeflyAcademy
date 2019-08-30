using FreeflyAcademy.Enums;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class TrackProgressSheetViewModel : BaseViewModel, ITrackProgressSheetViewModel
    {
        private AcquisitionLevel _securityAltitude;
        private AcquisitionLevel _securityHeading;
        private AcquisitionLevel _halfBarrel;
        private AcquisitionLevel _barrel;
        private AcquisitionLevel _speedUp;
        private AcquisitionLevel _slowDown;
        private AcquisitionLevel _levelControl;
        private AcquisitionLevel _inertiaControl;
        private AcquisitionLevel _back;
        private AcquisitionLevel _backWithHeading;
        private AcquisitionLevel _breakSignal;
        private AcquisitionLevel _breakHeading;
        private AcquisitionLevel _breakEfficiency;
        private AcquisitionLevel _breakBarrelAndOpeningSignal;

        public AcquisitionLevel SecurityAltitude
        {
            get => _securityAltitude;
            set
            {
                _securityAltitude = value;
                OnPropertyChanged(nameof(SecurityAltitude));
            }
        }
        public AcquisitionLevel SecurityHeading
        {
            get => _securityHeading;
            set
            {
                _securityHeading = value;
                OnPropertyChanged(nameof(SecurityHeading));
            }
        }
        public AcquisitionLevel HalfBarrel
        {
            get => _halfBarrel;
            set
            {
                _halfBarrel = value;
                OnPropertyChanged(nameof(HalfBarrel));
            }
        }
        public AcquisitionLevel Barrel
        {
            get => _barrel;
            set
            {
                _barrel = value;
                OnPropertyChanged(nameof(Barrel));
            }
        }
        public AcquisitionLevel SpeedUp
        {
            get => _speedUp;
            set
            {
                _speedUp = value;
                OnPropertyChanged(nameof(SpeedUp));
            }
        }
        public AcquisitionLevel SlowDown
        {
            get => _slowDown;
            set
            {
                _slowDown = value;
                OnPropertyChanged(nameof(SlowDown));
            }
        }
        public AcquisitionLevel LevelControl
        {
            get => _levelControl;
            set
            {
                _levelControl = value;
                OnPropertyChanged(nameof(LevelControl));
            }
        }
        public AcquisitionLevel InertiaControl
        {
            get => _inertiaControl;
            set
            {
                _inertiaControl = value;
                OnPropertyChanged(nameof(InertiaControl));
            }
        }
        public AcquisitionLevel Back
        {
            get => _back;
            set
            {
                _back = value;
                OnPropertyChanged(nameof(Back));
            }
        }
        public AcquisitionLevel BackWithHeading
        {
            get => _backWithHeading;
            set
            {
                _backWithHeading = value;
                OnPropertyChanged(nameof(BackWithHeading));
            }
        }
        public AcquisitionLevel BreakSignal
        {
            get => _breakSignal;
            set
            {
                _breakSignal = value;
                OnPropertyChanged(nameof(BreakSignal));
            }
        }
        public AcquisitionLevel BreakHeading
        {
            get => _breakHeading;
            set
            {
                _breakHeading = value;
                OnPropertyChanged(nameof(BreakHeading));
            }
        }
        public AcquisitionLevel BreakEfficiency
        {
            get => _breakEfficiency;
            set
            {
                _breakEfficiency = value;
                OnPropertyChanged(nameof(BreakEfficiency));
            }
        }
        public AcquisitionLevel BreakBarrelAndOpeningSignal
        {
            get => _breakBarrelAndOpeningSignal;
            set
            {
                _breakBarrelAndOpeningSignal = value;
                OnPropertyChanged(nameof(BreakBarrelAndOpeningSignal));
            }
        }
    }
}