using System;
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
    }
}