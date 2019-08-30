using System.Collections.ObjectModel;
using System.Windows.Input;
using FreeflyAcademy.Dtos;

namespace FreeflyAcademy.ViewModels.Contracts
{
    public interface ISkydiversViewModel : IBaseViewModel
    {
        ObservableCollection<ISkydiverTileViewModel> SkydiverTiles { get; set; }
        ICommand AddSkydiverCommand { get; }
    }
}
