using FreeflyAcademy.Enums;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Contracts;
using Ninject;

namespace FreeflyAcademy.ViewModels
{
    internal class ProgressSheetViewModel : BaseViewModel, IProgressSheetViewModel
    {
        private readonly IKernel _kernel;
        private readonly ISkydiverService _skydiverService;
        private readonly IProgressSheetService _progressSheetService;

        private AcquisitionLevel _headUpSecurityAltitude;
        private AcquisitionLevel _headUpSecurityReactivity;
        private AcquisitionLevel _headUpSecurityEase;
        private AcquisitionLevel _headUpSecurityHeading;
        private AcquisitionLevel _headUpSpin;
        private AcquisitionLevel _headUpLoop;
        private AcquisitionLevel _headUpBarrel;
        private AcquisitionLevel _headUpLevel;
        private AcquisitionLevel _headUpInertia;
        private AcquisitionLevel _headUpBreakAltitude;
        private AcquisitionLevel _headUpBreakSignal;
        private AcquisitionLevel _headUpBreakTrack;

        public ProgressSheetViewModel(IKernel kernel, ISkydiverService skydiverService, IProgressSheetService progressSheetService)
        {
            _kernel = kernel;
            _skydiverService = skydiverService;
            _progressSheetService = progressSheetService;
        }

        public ISkydiverViewModel SkydiversViewModel { get; private set; }


        private ITrackProgressSheetViewModel _trackProgressSheetViewModel;

        public ITrackProgressSheetViewModel TrackProgressSheetViewModel
        {
            get => _trackProgressSheetViewModel;
            set
            {
                _trackProgressSheetViewModel = value;
                OnPropertyChanged(nameof(TrackProgressSheetViewModel));
            }
        }



        //Module tête en haut
        public AcquisitionLevel HeadUpSecurityAltitude
        {
            get => _headUpSecurityAltitude;
            set => _headUpSecurityAltitude = value;
        }

        public AcquisitionLevel HeadUpSecurityReactivity
        {
            get => _headUpSecurityReactivity;
            set => _headUpSecurityReactivity = value;
        }

        public AcquisitionLevel HeadUpSecurityEase
        {
            get => _headUpSecurityEase;
            set => _headUpSecurityEase = value;
        }

        public AcquisitionLevel HeadUpSecurityHeading
        {
            get => _headUpSecurityHeading;
            set => _headUpSecurityHeading = value;
        }

        public AcquisitionLevel HeadUpSpin
        {
            get => _headUpSpin;
            set => _headUpSpin = value;
        }

        public AcquisitionLevel HeadUpLoop
        {
            get => _headUpLoop;
            set => _headUpLoop = value;
        }

        public AcquisitionLevel HeadUpBarrel
        {
            get => _headUpBarrel;
            set => _headUpBarrel = value;
        }

        public AcquisitionLevel HeadUpLevel
        {
            get => _headUpLevel;
            set => _headUpLevel = value;
        }

        public AcquisitionLevel HeadUpInertia
        {
            get => _headUpInertia;
            set => _headUpInertia = value;
        }

        public AcquisitionLevel HeadUpBreakAltitude
        {
            get => _headUpBreakAltitude;
            set => _headUpBreakAltitude = value;
        }

        public AcquisitionLevel HeadUpBreakSignal
        {
            get => _headUpBreakSignal;
            set => _headUpBreakSignal = value;
        }

        public AcquisitionLevel HeadUpBreakTrack

        {
            get => _headUpBreakTrack;
            set => _headUpBreakTrack = value;
        }

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



        public void Load(ISkydiverTileViewModel tile)
        {
            var skydiverDto = _skydiverService.Get(tile.FirstName, tile.LastName);

            SkydiversViewModel = _kernel.Get<ISkydiverViewModel>();
            SkydiversViewModel.FirstName = skydiverDto.FirstName;
            SkydiversViewModel.LastName = skydiverDto.LastName;
            SkydiversViewModel.VideoDirectoryPath = skydiverDto.VideoDirectoryPath;
            SkydiversViewModel.FreeflyStartingDate = skydiverDto.FreeflyStartingDate;
            SkydiversViewModel.JumpsCount = skydiverDto.JumpsCount;
            SkydiversViewModel.SkydiveStartingDate = skydiverDto.SkydiveStartingDate;
            SkydiversViewModel.PersonalRig = skydiverDto.PersonalRig;

            var progressSheetDto = _progressSheetService.GetOrCreate(tile.FirstName, tile.LastName);

            TrackProgressSheetViewModel = _kernel.Get<ITrackProgressSheetViewModel>();

            TrackProgressSheetViewModel.SecurityAltitude = progressSheetDto.TrackSecurityAltitude;
            TrackProgressSheetViewModel.InertiaControl = progressSheetDto.TrackInertiaControl;
            TrackProgressSheetViewModel.Back = progressSheetDto.TrackBack;
            TrackProgressSheetViewModel.BackWithHeading = progressSheetDto.TrackBackWithHeading;
            TrackProgressSheetViewModel.Barrel = progressSheetDto.TrackBarrel;
            TrackProgressSheetViewModel.BreakBarrelAndOpeningSignal = progressSheetDto.TrackBreakBarrelAndOpeningSignal;
            TrackProgressSheetViewModel.BreakEfficiency = progressSheetDto.TrackBreakEfficiency;
            TrackProgressSheetViewModel.BreakHeading = progressSheetDto.TrackBreakHeading;
            TrackProgressSheetViewModel.BreakSignal = progressSheetDto.TrackBreakSignal;
            TrackProgressSheetViewModel.HalfBarrel = progressSheetDto.TrackHalfBarrel;
            TrackProgressSheetViewModel.SlowDown = progressSheetDto.TrackSlowDown;
            TrackProgressSheetViewModel.SpeedUp = progressSheetDto.TrackSpeedUp;

            OnPropertyChanged(nameof(SkydiversViewModel));
        }
    }
}
