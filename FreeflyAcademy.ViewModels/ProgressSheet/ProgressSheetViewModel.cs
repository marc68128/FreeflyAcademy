using System;
using System.ComponentModel;
using System.IO;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class ProgressSheetViewModel : BaseViewModel, IProgressSheetViewModel
    {
        private readonly IKernel _kernel;
        private readonly ISkydiverService _skydiverService;
        private readonly IProgressSheetService _progressSheetService;
        
        public ProgressSheetViewModel(IKernel kernel, ISkydiverService skydiverService, IProgressSheetService progressSheetService)
        {
            _kernel = kernel;
            _skydiverService = skydiverService;
            _progressSheetService = progressSheetService;
        }

        public ISkydiverViewModel SkydiverViewModel { get; private set; }
        
        private ITrackProgressSheetViewModel _trackProgressSheetViewModel;
        private IHeadUpProgressSheetViewModel _headUpProgressSheetViewModel;
        private IHeadDownProgressSheetViewModel _headDownProgressSheetViewModel;

        public ITrackProgressSheetViewModel TrackProgressSheetViewModel
        {
            get => _trackProgressSheetViewModel;
            set
            {
                _trackProgressSheetViewModel = value;
                OnPropertyChanged(nameof(TrackProgressSheetViewModel));
            }
        }
        public IHeadUpProgressSheetViewModel HeadUpProgressSheetViewModel
        {
            get => _headUpProgressSheetViewModel;
            set
            {
                _headUpProgressSheetViewModel = value;
                OnPropertyChanged(nameof(_headUpProgressSheetViewModel));
            }
        }
        public IHeadDownProgressSheetViewModel HeadDownProgressSheetViewModel
        {
            get => _headDownProgressSheetViewModel;
            set
            {
                _headDownProgressSheetViewModel = value;
                OnPropertyChanged(nameof(HeadDownProgressSheetViewModel));
            } 
        }

        public void Load(ISkydiverTileViewModel tile)
        {
            Load(tile.FirstName, tile.LastName);
        }
        private void Load(string firstName, string lastName)
        {
            var skydiverDto = _skydiverService.Get(firstName, lastName);
            var progressSheetDto = _progressSheetService.GetOrCreate(firstName, lastName);

            InitSkydiverViewModel(skydiverDto);
            InitTrackProgressSheetViewModel(progressSheetDto);
            InitHeadUpProgressSheetViewModel(progressSheetDto);
            InitHeadDownProgressSheetViewModel(progressSheetDto);
        }

        public void OnFileDrop(string[] filepaths)
        {
            if (string.IsNullOrWhiteSpace(SkydiverViewModel.VideoDirectoryPath))
            {
                var infoModal = _kernel.Get<IModalInfoViewModel>();
                infoModal.Title = "Attention  !";
                infoModal.Content = $"Le dossier vidéo de {SkydiverViewModel.FirstName} {SkydiverViewModel.LastName} n'a pas été configuré.\n" +
                                    $"Vous ne pouvez pas ajouter de vidéos.";
                Messenger.Default.Send<IModalViewModel>(infoModal);
            }

            if (!Directory.Exists(SkydiverViewModel.VideoDirectoryPath))
            {
                var infoModal = _kernel.Get<IModalInfoViewModel>();
                infoModal.Title = "Attention  !";
                infoModal.Content = $"Le dossier \"{SkydiverViewModel.VideoDirectoryPath}\" configuré pour {SkydiverViewModel.FirstName} {SkydiverViewModel.LastName} n'éxiste pas.\n" +
                                    $"Veuillez le corriger afin de pouvoir ajouter des vidéos.";
                Messenger.Default.Send<IModalViewModel>(infoModal);
            }

            var selectCoachModal = _kernel.Get<ISelectCoachModalViewModel>();
            selectCoachModal.CoachSelected += (sender, model) =>
            {
                foreach (var filepath in filepaths)
                {
                    File.Copy(filepath,
                        Path.Combine(SkydiverViewModel.VideoDirectoryPath,
                            $"{DateTime.Now:yyMMddHHmm}_{model.FirstName}_{model.LastName}.{Path.GetExtension(filepath)}"));
                }
            };
            Messenger.Default.Send<IModalViewModel>(selectCoachModal);
        }

        private void InitSkydiverViewModel(SkydiverDto skydiverDto)
        {
            SkydiverViewModel = _kernel.Get<ISkydiverViewModel>();
            SkydiverViewModel.FirstName = skydiverDto.FirstName;
            SkydiverViewModel.LastName = skydiverDto.LastName;
            SkydiverViewModel.VideoDirectoryPath = skydiverDto.VideoDirectoryPath;
            SkydiverViewModel.FreeflyStartingDate = skydiverDto.FreeflyStartingDate;
            SkydiverViewModel.JumpsCount = skydiverDto.JumpsCount;
            SkydiverViewModel.SkydiveStartingDate = skydiverDto.SkydiveStartingDate;
            SkydiverViewModel.PersonalRig = skydiverDto.PersonalRig;
        }

        private void InitTrackProgressSheetViewModel(ProgressSheetDto progressSheet)
        {
            TrackProgressSheetViewModel = _kernel.Get<ITrackProgressSheetViewModel>();

            TrackProgressSheetViewModel.SecurityAltitude = progressSheet.TrackSecurityAltitude;
            TrackProgressSheetViewModel.InertiaControl = progressSheet.TrackInertiaControl;
            TrackProgressSheetViewModel.Back = progressSheet.TrackBack;
            TrackProgressSheetViewModel.BackWithHeading = progressSheet.TrackBackWithHeading;
            TrackProgressSheetViewModel.Barrel = progressSheet.TrackBarrel;
            TrackProgressSheetViewModel.BreakBarrelAndOpeningSignal = progressSheet.TrackBreakBarrelAndOpeningSignal;
            TrackProgressSheetViewModel.BreakEfficiency = progressSheet.TrackBreakEfficiency;
            TrackProgressSheetViewModel.BreakHeading = progressSheet.TrackBreakHeading;
            TrackProgressSheetViewModel.BreakSignal = progressSheet.TrackBreakSignal;
            TrackProgressSheetViewModel.HalfBarrel = progressSheet.TrackHalfBarrel;
            TrackProgressSheetViewModel.SlowDown = progressSheet.TrackSlowDown;
            TrackProgressSheetViewModel.SpeedUp = progressSheet.TrackSpeedUp;
            TrackProgressSheetViewModel.LevelControl = progressSheet.TrackLevelControl;

            TrackProgressSheetViewModel.PropertyChanged += TrackProgressSheetViewModelOnPropertyChanged;
        }

        private void TrackProgressSheetViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var selectCoachModal = _kernel.Get<IValidateCoachModalViewModel>();
            selectCoachModal.CoachSelected += (o, model) =>
            {
                _progressSheetService.Save(SkydiverViewModel.FirstName, SkydiverViewModel.LastName, GetProgressSheetDto());
            };
            selectCoachModal.Cancel += (o, model) =>
            {
                Load(SkydiverViewModel.FirstName, SkydiverViewModel.LastName);
            };
            Messenger.Default.Send<IModalViewModel>(selectCoachModal);
        }

        private void InitHeadUpProgressSheetViewModel(ProgressSheetDto progressSheet)
        {
            HeadUpProgressSheetViewModel = _kernel.Get<IHeadUpProgressSheetViewModel>();

            HeadUpProgressSheetViewModel.SecurityAltitude = progressSheet.HeadUpSecurityAltitude;
            HeadUpProgressSheetViewModel.Barrel = progressSheet.HeadUpBarrel;
            HeadUpProgressSheetViewModel.BreakAltitude = progressSheet.HeadUpBreakAltitude;
            HeadUpProgressSheetViewModel.BreakEfficiency = progressSheet.HeadUpBreakEfficiency;
            HeadUpProgressSheetViewModel.BreakSignal = progressSheet.HeadUpBreakSignal;
            HeadUpProgressSheetViewModel.BreakTrack = progressSheet.HeadUpBreakTrack;
            HeadUpProgressSheetViewModel.Inertia = progressSheet.HeadUpInertia;
            HeadUpProgressSheetViewModel.Level = progressSheet.HeadUpLevel;
            HeadUpProgressSheetViewModel.Loop = progressSheet.HeadUpLoop;
            HeadUpProgressSheetViewModel.SecurityEase = progressSheet.HeadUpSecurityEase;
            HeadUpProgressSheetViewModel.SecurityHeading = progressSheet.HeadUpSecurityHeading;
            HeadUpProgressSheetViewModel.Spin = progressSheet.HeadUpSpin;
        }

        private void InitHeadDownProgressSheetViewModel(ProgressSheetDto progressSheet)
        {
            HeadDownProgressSheetViewModel = _kernel.Get<IHeadDownProgressSheetViewModel>();
                
            HeadDownProgressSheetViewModel.SecurityAltitude = progressSheet.HeadDownSecurityAltitude;
            HeadDownProgressSheetViewModel.SecurityReactivity = progressSheet.HeadDownSecurityReactivity;
            HeadDownProgressSheetViewModel.Barrel = progressSheet.HeadDownBarrel;
            HeadDownProgressSheetViewModel.BreakSignal = progressSheet.HeadDownBreakSignal;
            HeadDownProgressSheetViewModel.Inertia = progressSheet.HeadDownInertia;
            HeadDownProgressSheetViewModel.Level = progressSheet.HeadDownLevel;
            HeadDownProgressSheetViewModel.Loop = progressSheet.HeadDownLoop;
            HeadDownProgressSheetViewModel.SecurityEase = progressSheet.HeadDownSecurityEase;
            HeadDownProgressSheetViewModel.SecurityHeading = progressSheet.HeadDownSecurityHeading;
            HeadDownProgressSheetViewModel.Spin = progressSheet.HeadDownSpin;
            HeadDownProgressSheetViewModel.Transition = progressSheet.HeadDownTransition;
            HeadDownProgressSheetViewModel.Break180Track = progressSheet.HeadDownBreak180Track;
            HeadDownProgressSheetViewModel.BreakBarrelAndOpeningSignal = progressSheet.HeadDownBreakBarrelAndOpeningSignal;
        }

        private ProgressSheetDto GetProgressSheetDto()
        {
            return new ProgressSheetDto
            {
                TrackSecurityAltitude = TrackProgressSheetViewModel.SecurityAltitude,
                TrackSecurityHeading = TrackProgressSheetViewModel.SecurityHeading,
                TrackHalfBarrel = TrackProgressSheetViewModel.HalfBarrel,
                TrackBarrel = TrackProgressSheetViewModel.Barrel,
                TrackSpeedUp = TrackProgressSheetViewModel.SpeedUp,
                TrackSlowDown = TrackProgressSheetViewModel.SlowDown,
                TrackLevelControl = TrackProgressSheetViewModel.LevelControl,
                TrackInertiaControl = TrackProgressSheetViewModel.InertiaControl,
                TrackBack = TrackProgressSheetViewModel.Back,
                TrackBackWithHeading = TrackProgressSheetViewModel.BackWithHeading,
                TrackBreakSignal = TrackProgressSheetViewModel.BreakSignal,
                TrackBreakHeading = TrackProgressSheetViewModel.BreakHeading,
                TrackBreakEfficiency = TrackProgressSheetViewModel.BreakEfficiency,
                TrackBreakBarrelAndOpeningSignal = TrackProgressSheetViewModel.BreakBarrelAndOpeningSignal,
                HeadUpSecurityAltitude = HeadUpProgressSheetViewModel.SecurityAltitude,
                HeadUpSecurityReactivity = HeadUpProgressSheetViewModel.SecurityReactivity,
                HeadUpSecurityEase = HeadUpProgressSheetViewModel.SecurityEase,
                HeadUpSecurityHeading = HeadUpProgressSheetViewModel.SecurityHeading,
                HeadUpSpin = HeadUpProgressSheetViewModel.Spin,
                HeadUpLoop = HeadUpProgressSheetViewModel.Loop,
                HeadUpBarrel = HeadUpProgressSheetViewModel.Barrel,
                HeadUpLevel = HeadUpProgressSheetViewModel.Level,
                HeadUpInertia = HeadUpProgressSheetViewModel.Inertia,
                HeadUpBreakAltitude = HeadUpProgressSheetViewModel.BreakAltitude,
                HeadUpBreakSignal = HeadUpProgressSheetViewModel.BreakSignal,
                HeadUpBreakTrack = HeadUpProgressSheetViewModel.BreakTrack,
                HeadUpBreakEfficiency = HeadUpProgressSheetViewModel.BreakEfficiency,
                HeadDownSecurityAltitude = HeadDownProgressSheetViewModel.SecurityAltitude,
                HeadDownSecurityReactivity = HeadDownProgressSheetViewModel.SecurityReactivity,
                HeadDownSecurityEase = HeadDownProgressSheetViewModel.SecurityEase,
                HeadDownSecurityHeading = HeadDownProgressSheetViewModel.SecurityHeading,
                HeadDownSpin = HeadDownProgressSheetViewModel.Spin,
                HeadDownLoop = HeadDownProgressSheetViewModel.Loop,
                HeadDownBarrel = HeadDownProgressSheetViewModel.Barrel,
                HeadDownTransition = HeadDownProgressSheetViewModel.Transition,
                HeadDownLevel = HeadDownProgressSheetViewModel.Level,
                HeadDownInertia = HeadDownProgressSheetViewModel.Inertia,
                HeadDownBreakSignal = HeadDownProgressSheetViewModel.BreakSignal,
                HeadDownBreak180Track = HeadDownProgressSheetViewModel.Break180Track,
                HeadDownBreakBarrelAndOpeningSignal = HeadDownProgressSheetViewModel.BreakBarrelAndOpeningSignal
            };
        }
    }
}
