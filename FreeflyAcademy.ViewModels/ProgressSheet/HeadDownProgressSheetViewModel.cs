using FreeflyAcademy.Enums;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class HeadDownProgressSheetViewModel : BaseViewModel, IHeadDownProgressSheetViewModel
    {
        private AcquisitionLevel _securityAltitude;
        private AcquisitionLevel _securityReactivity;
        private AcquisitionLevel _securityEase;
        private AcquisitionLevel _securityHeading;
        private AcquisitionLevel _spin;
        private AcquisitionLevel _loop;
        private AcquisitionLevel _barrel;
        private AcquisitionLevel _transition;
        private AcquisitionLevel _level;
        private AcquisitionLevel _inertia;
        private AcquisitionLevel _breakSignal;
        private AcquisitionLevel _break180Track;
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
        public AcquisitionLevel SecurityReactivity
        {
            get => _securityReactivity;
            set
            {
                _securityReactivity = value;
                OnPropertyChanged(nameof(SecurityReactivity));
            }
        }
        public AcquisitionLevel SecurityEase
        {
            get => _securityEase;
            set
            {
                _securityEase = value;
                OnPropertyChanged(nameof(SecurityEase));
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
        public AcquisitionLevel Spin
        {
            get => _spin;
            set
            {
                _spin = value;
                OnPropertyChanged(nameof(Spin));
            }
        }
        public AcquisitionLevel Loop
        {
            get => _loop;
            set
            {
                _loop = value;
                OnPropertyChanged(nameof(Loop));
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
        public AcquisitionLevel Transition
        {
            get => _transition;
            set
            {
                _transition = value;
                OnPropertyChanged(nameof(Transition));
            }
        }
        public AcquisitionLevel Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public AcquisitionLevel Inertia
        {
            get => _inertia;
            set
            {
                _inertia = value;
                OnPropertyChanged(nameof(Inertia));
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
        public AcquisitionLevel Break180Track
        {
            get => _break180Track;
            set
            {
                _break180Track = value;
                OnPropertyChanged(nameof(Break180Track));
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