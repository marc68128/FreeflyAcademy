using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using GalaSoft.MvvmLight.CommandWpf;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Input;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class FileViewModel : IFileViewModel
    {
        public FileViewModel()
        {
            InitCommands();
        }

        public string Path { get; set; }
        public string FileName { get; set; }
        public Bitmap Icon { get; set; }

        public ICommand OpenCommand { get; private set; }

        public IFileViewModel Initialize(string path)
        {
            Path = path;
            FileName = System.IO.Path.GetFileNameWithoutExtension(Path);
            InitIcon();
            return this;
        }
        private void InitIcon()
        {
            using (Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(Path))
            {
                Icon = sysicon.ToBitmap();
            }
        }
        private void InitCommands()
        {
            OpenCommand = new RelayCommand(() =>
            {
                if (File.Exists(Path))
                    Process.Start(Path);
            });
        }
    }
}