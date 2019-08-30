using FreeflyAcademy.Domain;
using System.Collections.Generic;

namespace FreeflyAcademy.Repositories.Contracts
{
    public interface ISkydiverRepository
    {
        List<Skydiver> GetAll();
        void Add(Skydiver skydiver);
        Skydiver Get(string firstName, string lastName);
    }
}
