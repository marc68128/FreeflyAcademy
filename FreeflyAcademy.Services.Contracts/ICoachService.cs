using FreeflyAcademy.Dtos;
using System.Collections.Generic;

namespace FreeflyAcademy.Services.Contracts
{
    public interface ICoachService
    {
        List<CoachDto> GetAll();
    }
}
