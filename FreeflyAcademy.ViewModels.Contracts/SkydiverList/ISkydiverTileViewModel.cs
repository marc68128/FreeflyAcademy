using System.Windows.Input;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.SkydiverList
{
    public interface ISkydiverTileViewModel : IBaseViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        ICommand OpenCommand { get; }
    }
}
