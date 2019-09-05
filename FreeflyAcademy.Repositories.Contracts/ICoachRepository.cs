using System.Collections.Generic;
using FreeflyAcademy.Domain.Model;

namespace FreeflyAcademy.Repositories.Contracts
{
    public interface ICoachRepository
    {
        List<Coach> GetAll(); 
    }
}
