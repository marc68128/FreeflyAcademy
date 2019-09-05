using FreeflyAcademy.Domain.Model;
using FreeflyAcademy.Dtos;

namespace FreeflyAcademy.Services.Configuration
{
    public class ServicesMappingProfile : AutoMapper.Profile
    {
        public ServicesMappingProfile()
        {
            CreateTwoWayMap<Skydiver, SkydiverDto>();
            CreateTwoWayMap<Coach, CoachDto>();
            CreateTwoWayMap<ProgressSheet, ProgressSheetDto>();
            CreateTwoWayMap<TrackProgressSheet, TrackProgressSheetDto>();
            CreateTwoWayMap<HeadUpProgressSheet, HeadUpProgressSheetDto>();
            CreateTwoWayMap<HeadDownProgressSheet, HeadDownProgressSheetDto>();
        }

        private void CreateTwoWayMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}
