using System.Collections.Generic;
using FreeflyAcademy.Dtos;

namespace FreeflyAcademy.Services.Contracts.Business
{
    public interface ICoachService
    {
        List<CoachDto> GetAll();
    }
}
