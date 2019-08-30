namespace FreeflyAcademy.ViewModels.Contracts
{
    public interface IProgressSheetViewModel : IBaseViewModel
    {
        ISkydiverViewModel SkydiversViewModel { get; }

        ITrackProgressSheetViewModel  TrackProgressSheetViewModel { get; set; }

        void Load(ISkydiverTileViewModel tiles);
    }
}
