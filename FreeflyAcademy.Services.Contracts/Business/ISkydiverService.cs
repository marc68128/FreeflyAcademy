using System.Collections.Generic;
using FreeflyAcademy.Dtos;

namespace FreeflyAcademy.Services.Contracts.Business
{
    public interface ISkydiverService
    {
        List<SkydiverDto> GetAll();
        SkydiverDto Get(string firstName, string lastName);
        void Add(SkydiverDto skydiver);
        void Edit(SkydiverDto skydiver);
    }
}
