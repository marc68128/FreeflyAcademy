﻿using System;

namespace FreeflyAcademy.ViewModels.Contracts
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