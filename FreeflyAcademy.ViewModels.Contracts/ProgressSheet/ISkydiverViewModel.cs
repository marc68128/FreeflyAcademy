using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface ISkydiverViewModel : IBaseViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string VideoDirectoryPath { get; set; }
        bool PersonalRig { get; set; }
        int JumpsCount { get; set; }
        DateTime? SkydiveStartingDate { get; set; }
        DateTime? FreeflyStartingDate { get; set; }
        string SelectedSubFolder { set; }
        bool IsLoading { get; }

        ObservableCollection<IFileViewModel> Files { get; }

        ICommand OpenFolderCommand { get; }
        ICommand EditCommand { get; }
        

        ISkydiverViewModel Initialize(string firstName, string lastName);
        void AddFiles(string[] filePaths);
    }
}