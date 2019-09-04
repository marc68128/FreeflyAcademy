using AutoMapper;
using FreeflyAcademy.Domain;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Repositories.Contracts;
using FreeflyAcademy.Services.Contracts;

namespace FreeflyAcademy.Services
{
    internal class ProgressSheetService : IProgressSheetService
    {
        private readonly IProgressSheetRepository _progressSheetRepository;

        public ProgressSheetService(IProgressSheetRepository progressSheetRepository)
        {
            _progressSheetRepository = progressSheetRepository;
        }

        public ProgressSheetDto GetOrCreate(string firstName, string lastName)
        {
            var progressSheet = _progressSheetRepository.GetOrCreate(firstName, lastName);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProgressSheet, ProgressSheetDto>();
                cfg.CreateMap<TrackProgressSheet, TrackProgressSheetDto>();
                cfg.CreateMap<HeadUpProgressSheet, HeadUpProgressSheetDto>();
                cfg.CreateMap<HeadDownProgressSheet, HeadDownProgressSheetDto>();
            });
            var progressSheetDto = config.CreateMapper().Map<ProgressSheetDto>(progressSheet);

            return progressSheetDto;
        }

        public void Save(string firstName, string lastName, ProgressSheetDto progressSheetDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProgressSheetDto, ProgressSheet>();
                cfg.CreateMap<TrackProgressSheetDto, TrackProgressSheet>();
                cfg.CreateMap<HeadUpProgressSheetDto, HeadUpProgressSheet>();
                cfg.CreateMap<HeadDownProgressSheetDto, HeadDownProgressSheet>();
            });

            var progressSheet = config.CreateMapper().Map<ProgressSheet>(progressSheetDto);

            _progressSheetRepository.Save(firstName, lastName, progressSheet);
        }

        public void Save(string firstName, string lastName, TrackProgressSheetDto trackProgressSheetDto)
        {
            var progressSheetDto = GetOrCreate(firstName, lastName);
            progressSheetDto.TrackProgressSheet = trackProgressSheetDto; 
            Save(firstName, lastName, progressSheetDto);
        }

        public void Save(string firstName, string lastName, HeadUpProgressSheetDto headUpProgressSheetDto)
        {
            var progressSheetDto = GetOrCreate(firstName, lastName);
            progressSheetDto.HeadUpProgressSheet = headUpProgressSheetDto;
            Save(firstName, lastName, progressSheetDto);
        }

        public void Save(string firstName, string lastName, HeadDownProgressSheetDto headDownProgressSheetDto)
        {
            var progressSheetDto = GetOrCreate(firstName, lastName);
            progressSheetDto.HeadDownProgressSheet = headDownProgressSheetDto;
            Save(firstName, lastName, progressSheetDto);
        }
    }
}
