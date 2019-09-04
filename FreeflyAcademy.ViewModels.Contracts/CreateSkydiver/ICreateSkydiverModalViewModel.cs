using System;
using System.Windows.Input;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.CreateSkydiver
{
    public interface ICreateSkydiverModalViewModel : IModalViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string VideoDirectoryPath { get; set; }
        bool PersonalRig { get; set; }
        int JumpsCount { get; set; }
        DateTime? SkydiveStartingDate { get; set; }
        DateTime? FreeflyStartingDate { get; set; }

        ICommand SaveCommand { get; }
        ICommand CancelCommand { get; }
    }
}
