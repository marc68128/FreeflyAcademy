﻿using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface IProgressSheetViewModel : IBaseViewModel, IDragDropTarget
    {
        ISkydiverViewModel SkydiversViewModel { get; }

        ITrackProgressSheetViewModel  TrackProgressSheetViewModel { get; set; }
        IHeadUpProgressSheetViewModel HeadUpProgressSheetViewModel { get; set; }
        IHeadDownProgressSheetViewModel HeadDownProgressSheetViewModel { get; set; }

        void Load(ISkydiverTileViewModel tiles);
    }
}