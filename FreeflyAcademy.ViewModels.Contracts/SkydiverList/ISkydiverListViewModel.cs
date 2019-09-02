using System.Collections.ObjectModel;
using System.Windows.Input;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.SkydiverList
{
    public interface ISkydiverListViewModel : IBaseViewModel
    {
        ObservableCollection<ISkydiverTileViewModel> FilteredSkydiverTiles { get; set; }
        ICommand AddSkydiverCommand { get; }
        string SearchText { get; set; }
    }
}
