﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface ISelectCoachModalViewModel : IModalViewModel
    {
        event EventHandler<ICoachTileViewModel> CoachSelected;

        ICommand ValidateCommand { get; }
        ICommand CancelCommand { get; }

        List<ICoachTileViewModel> Coaches { get; }
        ICoachTileViewModel SelectedCoach { get; set; }
    }
}
