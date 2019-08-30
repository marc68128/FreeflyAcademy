using FreeflyAcademy.Domain;
using FreeflyAcademy.Domain.Exception;
using FreeflyAcademy.Repositories.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FreeflyAcademy.Repositories
{
    internal class CoachRepository : AbstractFolderRepository, ICoachRepository
    {
        public List<Coach> GetAll()
        {
            var coachsFile = Path.Combine(_repositoryFolderPath, "coach.db");

            if (!File.Exists(coachsFile))
                throw new FreeflyAcademyException("Le fichier de base de donées des coachs n'éxiste pas.");

            return JsonConvert.DeserializeObject<List<Coach>>(File.ReadAllText(coachsFile));
        }
    }
}
