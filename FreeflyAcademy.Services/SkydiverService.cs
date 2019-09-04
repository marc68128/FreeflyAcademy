using FreeflyAcademy.Dtos;
using FreeflyAcademy.Repositories.Contracts;
using FreeflyAcademy.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using FreeflyAcademy.Domain;

namespace FreeflyAcademy.Services
{
    internal class SkydiverService : ISkydiverService
    {
        private readonly ISkydiverRepository _skydiverRepository;

        public SkydiverService(ISkydiverRepository skydiverRepository)
        {
            _skydiverRepository = skydiverRepository;
        }

        public List<SkydiverDto> GetAll()
        {
            return _skydiverRepository
                .GetAll()
                .Select(s => new SkydiverDto
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName, 
                    JumpsCount = s.JumpsCount, 
                    PersonalRig = s.PersonalRig, 
                    FreeflyStartingDate = s.FreeflyStartingDate, 
                    SkydiveStartingDate = s.SkydiveStartingDate, 
                    VideoDirectoryPath = s.VideoDirectoryPath
                }).ToList();
        }

        public SkydiverDto Get(string firstName, string lastName)
        {
            var skydiver = _skydiverRepository.Get(firstName, lastName); 

            return new SkydiverDto
            {
                FirstName = skydiver.FirstName,
                LastName = skydiver.LastName,
                JumpsCount = skydiver.JumpsCount,
                PersonalRig = skydiver.PersonalRig,
                FreeflyStartingDate = skydiver.FreeflyStartingDate,
                SkydiveStartingDate = skydiver.SkydiveStartingDate,
                VideoDirectoryPath = skydiver.VideoDirectoryPath
            };
        }

        public void Add(SkydiverDto skydiver)
        {
            _skydiverRepository.Add(new Skydiver
            {
                FirstName = skydiver.FirstName, 
                LastName = skydiver.LastName,
                JumpsCount = skydiver.JumpsCount,
                PersonalRig = skydiver.PersonalRig,
                FreeflyStartingDate = skydiver.FreeflyStartingDate,
                SkydiveStartingDate = skydiver.SkydiveStartingDate, 
                VideoDirectoryPath = skydiver.VideoDirectoryPath
            });
        }

        public void Edit(SkydiverDto skydiver)
        {
            _skydiverRepository.Edit(new Skydiver
            {
                FirstName = skydiver.FirstName,
                LastName = skydiver.LastName,
                JumpsCount = skydiver.JumpsCount,
                PersonalRig = skydiver.PersonalRig,
                FreeflyStartingDate = skydiver.FreeflyStartingDate,
                SkydiveStartingDate = skydiver.SkydiveStartingDate,
                VideoDirectoryPath = skydiver.VideoDirectoryPath
            });
        }
    }
}
