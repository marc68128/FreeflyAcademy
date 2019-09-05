using AutoMapper;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.CreateSkydiver;
using FreeflyAcademy.ViewModels.SkydiverList;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;
using System;
using System.Windows.Input;

namespace FreeflyAcademy.ViewModels.CreateSkydiver
{
    internal class CreateSkydiverModalModalViewModel : BaseViewModel, ICreateSkydiverModalViewModel
    {
        private readonly ISkydiverService _skydiverService;

        public CreateSkydiverModalModalViewModel(IKernel kernel, IMapper mapper, ISkydiverService skydiverService) : base(kernel, mapper)
        {
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

                Messenger.Default.Send<IBaseViewModel>(_kernel.Get<SkydiverListViewModel>());
                Messenger.Default.Send<IModalViewModel>(null);
            });

            CancelCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<IModalViewModel>(null);
            });
        }
    }
}
