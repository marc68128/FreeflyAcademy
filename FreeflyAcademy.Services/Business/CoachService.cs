using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Repositories.Contracts;
using FreeflyAcademy.Services.Contracts.Business;

namespace FreeflyAcademy.Services.Business
{
    internal class CoachService : BaseBusinessService, ICoachService
    {
        private readonly ICoachRepository _coachRepository;

        public CoachService(IMapper mapper, ICoachRepository coachRepository) : base(mapper)
        {
            _coachRepository = coachRepository;
        }

        public List<CoachDto> GetAll()
        {
            return _coachRepository.GetAll().Select(c => _mapper.Map<CoachDto>(c)).ToList();
        }
    }
}
