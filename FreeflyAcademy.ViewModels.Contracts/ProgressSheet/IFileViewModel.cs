using System.Drawing;
using System.Windows.Input;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface IFileViewModel
    {
        string Path { get; set; }
        string FileName { get; set; }
        Bitmap Icon { get; set; }

        ICommand OpenCommand { get; }

        IFileViewModel Initialize(string path);
    }
}
