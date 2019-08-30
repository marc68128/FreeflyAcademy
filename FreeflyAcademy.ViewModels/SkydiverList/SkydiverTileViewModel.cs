using System.Windows.Input;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.SkydiverList
{
    internal class SkydiverTileViewModel : BaseViewModel, ISkydiverTileViewModel
    {
        private readonly IKernel _kernel;

        public SkydiverTileViewModel(IKernel kernel)
        {
            _kernel = kernel;
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
