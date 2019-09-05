using FreeflyAcademy.Dtos;
using FreeflyAcademy.ViewModels.Contracts.EditSkydiver;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using FreeflyAcademy.ViewModels.ProgressSheet;

namespace FreeflyAcademy.ViewModels.Configuration
{
    public class ViewModelsMappingProfile : AutoMapper.Profile
    {
        public ViewModelsMappingProfile()
        {
            CreateMap<SkydiverDto, ISkydiverTileViewModel>();
            CreateTwoWayMap<SkydiverDto, IEditSkydiverModalViewModel>();
            CreateMap<CoachDto, ICoachTileViewModel>();
            CreateTwoWayMap<TrackProgressSheetDto, TrackProgressSheetViewModel>();
            CreateTwoWayMap<HeadUpProgressSheetDto, HeadUpProgressSheetViewModel>();
            CreateTwoWayMap<HeadDownProgressSheetDto, HeadDownProgressSheetViewModel>();
        }

        private void CreateTwoWayMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
