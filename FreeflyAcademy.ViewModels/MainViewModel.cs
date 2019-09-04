using System;
using System.Windows.Input;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels
{
    internal class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IKernel _kernel;
        private IBaseViewModel _viewModel;
        private IModalViewModel _modalViewModel;
        private bool _showModal;


        public MainViewModel(IKernel kernel)
        {
            Messenger.Default.Register(this, new Action<IBaseViewModel>(SetupViewModel));
            Messenger.Default.Register(this, new Action<IModalViewModel>(SetupModalViewModel));

            _kernel = kernel;
            SetupViewModel(_kernel.Get<ISkydiverListViewModel>());
            InitCommands();
        }


        private void SetupViewModel(IBaseViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        private void SetupModalViewModel(IModalViewModel modalViewModel)
        {
            ModalViewModel = modalViewModel;
            ShowModal = modalViewModel != null;
        }
        
        public IBaseViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public IModalViewModel ModalViewModel
        {
            get => _modalViewModel;
            set
            {
                _modalViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToHomeCommand { get; private set; }

        public bool ShowModal
        {
            get => _showModal;
            set
            {
                _showModal = value;
                OnPropertyChanged();
            }
        }

        private void InitCommands()
        {
            NavigateToHomeCommand = new RelayCommand(() => ViewModel = _kernel.Get<ISkydiverListViewModel>());
        }

    }
}
