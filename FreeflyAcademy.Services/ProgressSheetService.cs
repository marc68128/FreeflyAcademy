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

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProgressSheet, ProgressSheetDto>());
            var progressSheetDto = config.CreateMapper().Map<ProgressSheetDto>(progressSheet);

            return progressSheetDto;
        }

        public void Save(string firstName, string lastName, ProgressSheetDto progressSheetDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProgressSheetDto, ProgressSheet>());
            var progressSheet = config.CreateMapper().Map<ProgressSheet>(progressSheetDto);

            _progressSheetRepository.Save(firstName, lastName, progressSheet);
        }
    }
}
