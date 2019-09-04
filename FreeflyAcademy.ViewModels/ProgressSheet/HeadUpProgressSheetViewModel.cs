using FreeflyAcademy.Dtos;
using FreeflyAcademy.Enums;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class HeadUpProgressSheetViewModel : ProgressSheetModuleViewModel<HeadUpProgressSheetDto>, IHeadUpProgressSheetViewModel
    {
        private AcquisitionLevel _securityAltitude;
        private AcquisitionLevel _securityReactivity;
        private AcquisitionLevel _securityEase;
        private AcquisitionLevel _securityHeading;
        private AcquisitionLevel _spin;
        private AcquisitionLevel _loop;
        private AcquisitionLevel _barrel;
        private AcquisitionLevel _level;
        private AcquisitionLevel _inertia;
        private AcquisitionLevel _breakAltitude;
        private AcquisitionLevel _breakSignal;
        private AcquisitionLevel _breakTrack;
        private AcquisitionLevel _breakEfficiency;

        public HeadUpProgressSheetViewModel(IKernel kernel, IProgressSheetService progressSheetService) : base(kernel, progressSheetService)
        {
        }

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
        public AcquisitionLevel BreakAltitude
        {
            get => _breakAltitude;
            set
            {
                _breakAltitude = value;
                OnPropertyChanged(nameof(BreakAltitude));
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
        public AcquisitionLevel BreakTrack

        {
            get => _breakTrack;
            set
            {
                _breakTrack = value;
                OnPropertyChanged(nameof(BreakTrack));
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
        
        public override void Initialize(string firstName, string lastName, ProgressSheetDto progressSheet)
        {
            PropertyChanged -= ProgressSheetViewModelOnPropertyChanged;

            FirstName = firstName;
            LastName = lastName;

            SecurityAltitude = progressSheet.HeadUpProgressSheet.SecurityAltitude;
            SecurityReactivity = progressSheet.HeadUpProgressSheet.SecurityReactivity;
            SecurityEase = progressSheet.HeadUpProgressSheet.SecurityEase;
            SecurityHeading = progressSheet.HeadUpProgressSheet.SecurityHeading;
            Spin = progressSheet.HeadUpProgressSheet.Spin;
            Barrel = progressSheet.HeadUpProgressSheet.Barrel;
            Loop = progressSheet.HeadUpProgressSheet.Loop;
            Level = progressSheet.HeadUpProgressSheet.Level;
            Inertia = progressSheet.HeadUpProgressSheet.Inertia;
            BreakAltitude = progressSheet.HeadUpProgressSheet.BreakAltitude;
            BreakSignal = progressSheet.HeadUpProgressSheet.BreakSignal;
            BreakTrack = progressSheet.HeadUpProgressSheet.BreakTrack;
            BreakEfficiency = progressSheet.HeadUpProgressSheet.BreakEfficiency;

            Validated = progressSheet.HeadUpProgressSheet.Validated;
            ValidationDate = progressSheet.HeadUpProgressSheet.ValidationDate;
            Coach = progressSheet.HeadUpProgressSheet.Coach;

            PropertyChanged += ProgressSheetViewModelOnPropertyChanged;
        }

        public override HeadUpProgressSheetDto GetProgressSheetDto()
        {
            return new HeadUpProgressSheetDto
            {
                SecurityAltitude = SecurityAltitude,
                SecurityReactivity = SecurityReactivity,
                SecurityEase = SecurityEase,
                SecurityHeading = SecurityHeading,
                Spin = Spin,
                Loop = Loop,
                Barrel = Barrel,
                Level = Level,
                Inertia = Inertia,
                BreakAltitude = BreakAltitude,
                BreakSignal = BreakSignal,
                BreakTrack = BreakTrack,
                BreakEfficiency = BreakEfficiency,

                Validated = Validated,
                Coach = Coach,
                ValidationDate = ValidationDate
            };
        }

        protected override void Save()
        {
            _progressSheetService.Save(FirstName, LastName, GetProgressSheetDto());
        }
    }
}