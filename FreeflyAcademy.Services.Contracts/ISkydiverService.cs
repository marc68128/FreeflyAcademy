using FreeflyAcademy.Domain;
using System.Collections.Generic;
using FreeflyAcademy.Dtos;

namespace FreeflyAcademy.Services.Contracts
{
    public interface ISkydiverService
    {
        List<SkydiverDto> GetAll();
        SkydiverDto Get(string firstName, string lastName);
        void Add(SkydiverDto skydiver);
    }
}
