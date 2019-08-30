using System;
using System.Windows.Input;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Contracts;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels
{
    internal class SkydiverTileViewModel : BaseViewModel, ISkydiverTileViewModel
    {
        private readonly IKernel _kernel;
        private readonly ISkydiverService _skydiverService;

        public SkydiverTileViewModel(IKernel kernel, ISkydiverService skydiverService)
        {
            _kernel = kernel;
            _skydiverService = skydiverService;
            InitCommands();
        }

        private string _firstName;
        private string _lastName;
        
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

        public ICommand OpenCommand { get; private set; }

        private void InitCommands()
        {
            OpenCommand = new RelayCommand(() =>
            {
                var viewModel = _kernel.Get<IProgressSheetViewModel>();
                viewModel.Load(this);
                Messenger.Default.Send<IBaseViewModel>(viewModel);
            });
        }

    }
}
