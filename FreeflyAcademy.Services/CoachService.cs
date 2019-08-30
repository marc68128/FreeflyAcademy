using FreeflyAcademy.Dtos;
using FreeflyAcademy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FreeflyAcademy.Domain;
using FreeflyAcademy.Repositories.Contracts;

namespace FreeflyAcademy.Services
{
    internal class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;

        public CoachService(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        public List<CoachDto> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Coach, CoachDto>());
            var mapper = config.CreateMapper();
            return _coachRepository.GetAll().Select(c => mapper.Map<CoachDto>(c)).ToList();
        }
    }
}
