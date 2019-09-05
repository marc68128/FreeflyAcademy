using AutoMapper;
using FreeflyAcademy.Domain.Model;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Repositories.Contracts;
using FreeflyAcademy.Services.Contracts.Business;

namespace FreeflyAcademy.Services.Business
{
    internal class ProgressSheetService : BaseBusinessService, IProgressSheetService
    {
        private readonly IProgressSheetRepository _progressSheetRepository;

        public ProgressSheetService(IMapper mapper, IProgressSheetRepository progressSheetRepository) : base(mapper)
        {
            _progressSheetRepository = progressSheetRepository;
        }

        public ProgressSheetDto GetOrCreate(string firstName, string lastName)
        {
            var progressSheet = _progressSheetRepository.GetOrCreate(firstName, lastName);
            var progressSheetDto = _mapper.Map<ProgressSheetDto>(progressSheet);

            return progressSheetDto;
        }

        public void Save(string firstName, string lastName, ProgressSheetDto progressSheetDto)
        {
            var progressSheet = _mapper.Map<ProgressSheet>(progressSheetDto);
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
