using System;
using System.Windows.Input;
using AutoMapper;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.EditSkydiver;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.EditSkydiver
{
    internal class EditSkydiverModalViewModel : BaseViewModel, IEditSkydiverModalViewModel
    {
        private readonly ISkydiverService _skydiverService;

        public EditSkydiverModalViewModel(IKernel kernel, IMapper mapper, ISkydiverService skydiverService) : base(kernel, mapper)
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

        public IEditSkydiverModalViewModel Initialize(string firstName, string lastName)
        {
            _mapper.Map(_skydiverService.Get(firstName, lastName), this);
            return this; 
        }

        private void InitCommands()
        {
            SaveCommand = new RelayCommand(() =>
            {
                _skydiverService.Edit(_mapper.Map<SkydiverDto>(this));

                var progressSheetViewModel = _kernel.Get<IProgressSheetViewModel>(); 
                progressSheetViewModel.Load(FirstName, LastName);
                Messenger.Default.Send<IBaseViewModel>(progressSheetViewModel);
                Messenger.Default.Send<IModalViewModel>(null);
            });

            CancelCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<IModalViewModel>(null);
            });
        }
    }
}
