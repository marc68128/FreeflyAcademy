using System.Collections.Generic;
using FreeflyAcademy.Domain.Model;

namespace FreeflyAcademy.Repositories.Contracts
{
    public interface ISkydiverRepository
    {
        List<Skydiver> GetAll();
        void Add(Skydiver skydiver);
        Skydiver Get(string firstName, string lastName);
        void Edit(Skydiver skydiver);
    }
}
