using FreeflyAcademy.ViewModels.Contracts.Base;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace FreeflyAcademy.ViewModels.Base
{
    internal class ModalInfoViewModel : BaseViewModel, IModalInfoViewModel
    {
        public ModalInfoViewModel()
        {
            InitCommands();
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public ICommand OkCommand { get; private set; }

        private void InitCommands()
        {
            OkCommand = new RelayCommand(() => Messenger.Default.Send<IModalViewModel>(null));
        }
    }
}
