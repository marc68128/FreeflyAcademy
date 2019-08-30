using System;
using FreeflyAcademy.ViewModels.Contracts;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels
{
    internal class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IKernel _kernel;
        private IBaseViewModel _viewModel;

        public MainViewModel(IKernel kernel)
        {
            Messenger.Default.Register(this, new Action<IBaseViewModel>(SetupViewModel));
            _kernel = kernel;
            SetupViewModel(_kernel.Get<ISkydiversViewModel>());
        }

        private void SetupViewModel(IBaseViewModel viewModel)
        {
            ViewModel = viewModel;
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
    }
}
