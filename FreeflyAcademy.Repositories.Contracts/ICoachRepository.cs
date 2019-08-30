using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeflyAcademy.Domain;

namespace FreeflyAcademy.Repositories.Contracts
{
    public interface ICoachRepository
    {
        List<Coach> GetAll(); 
    }
}
