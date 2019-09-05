using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FreeflyAcademy.Domain.Model;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Repositories.Contracts;
using FreeflyAcademy.Services.Contracts.Business;

namespace FreeflyAcademy.Services.Business
{
    internal class SkydiverService : BaseBusinessService, ISkydiverService
    {
        private readonly ISkydiverRepository _skydiverRepository;

        public SkydiverService(IMapper mapper, ISkydiverRepository skydiverRepository) : base(mapper)
        {
            _skydiverRepository = skydiverRepository;
        }

        public List<SkydiverDto> GetAll()
        {
            return _skydiverRepository
                .GetAll()
                .Select(s => _mapper.Map<SkydiverDto>(s))
                .ToList();
        }

        public SkydiverDto Get(string firstName, string lastName)
        {
            var skydiver = _skydiverRepository.Get(firstName, lastName);
            return _mapper.Map<SkydiverDto>(skydiver);
        }

        public void Add(SkydiverDto skydiver)
        {
            _skydiverRepository.Add(_mapper.Map<Skydiver>(skydiver));
        }

        public void Edit(SkydiverDto skydiver)
        {
            _skydiverRepository.Edit(_mapper.Map<Skydiver>(skydiver));
        }
    }
}
