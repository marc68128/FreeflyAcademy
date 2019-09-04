using System.Windows.Input;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts
{
    public interface IMainViewModel : IBaseViewModel
    {
        IBaseViewModel ViewModel { get; }
        IModalViewModel ModalViewModel { get; }

        bool ShowModal { get; }
        ICommand NavigateToHomeCommand { get; }
    }
}
