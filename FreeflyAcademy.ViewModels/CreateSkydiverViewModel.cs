using System;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Contracts;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace FreeflyAcademy.ViewModels
{
    internal class CreateSkydiverViewModel : BaseViewModel, ICreateSkydiverViewModel
    {
        private readonly IKernel _kernel;
        private readonly ISkydiverService _skydiverService;

        public CreateSkydiverViewModel(IKernel kernel, ISkydiverService skydiverService)
        {
            _kernel = kernel;
            _skydiverService = skydiverService;
            InitCommands();
        }

        private string _firstName;
        private string _lastName;
        private string _videoDirectoryPath;
        private bool _personalRig;
        private int _jumpsCount;
        private DateTime? _skydiveStartingDate;
        private DateTime? _freeflyStartingDate;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string VideoDirectoryPath
        {
            get => _videoDirectoryPath;
            set
            {
                _videoDirectoryPath = value;
                OnPropertyChanged(nameof(VideoDirectoryPath));
            }
        }
        public bool PersonalRig
        {
            get => _personalRig;
            set
            {
                _personalRig = value;
                OnPropertyChanged(nameof(PersonalRig));
            }
        }
        public int JumpsCount
        {
            get => _jumpsCount;
            set
            {
                _jumpsCount = value;
                OnPropertyChanged(nameof(JumpsCount));
            }
        }
        public DateTime? SkydiveStartingDate
        {
            get => _skydiveStartingDate;
            set
            {
                _skydiveStartingDate = value;
                OnPropertyChanged(nameof(SkydiveStartingDate));
            }
        }
        public DateTime? FreeflyStartingDate
        {
            get => _freeflyStartingDate;
            set
            {
                _freeflyStartingDate = value;
                OnPropertyChanged(nameof(FreeflyStartingDate));
            }
        }
        
        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        private void InitCommands()
        {
            SaveCommand = new RelayCommand(() =>
            {
                _skydiverService.Add(new SkydiverDto
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    VideoDirectoryPath = VideoDirectoryPath, 
                    PersonalRig = PersonalRig, 
                    JumpsCount = JumpsCount,
                    SkydiveStartingDate = SkydiveStartingDate,
                    FreeflyStartingDate = FreeflyStartingDate
                });

                Messenger.Default.Send<IBaseViewModel>(_kernel.Get<SkydiversViewModel>());
            });

            CancelCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<IBaseViewModel>(_kernel.Get<SkydiversViewModel>());
            });
        }
    }
}
