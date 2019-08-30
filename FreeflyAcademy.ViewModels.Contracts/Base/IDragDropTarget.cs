namespace FreeflyAcademy.ViewModels.Contracts.Base
{
    public interface IDragDropTarget
    {
        void OnFileDrop(string[] filepaths);
    }
}