using FreeflyAcademy.Domain;
using FreeflyAcademy.Repositories.Contracts;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using FreeflyAcademy.Domain.Exception;
using FreeflyAcademy.Enums;
using Newtonsoft.Json;

namespace FreeflyAcademy.Repositories
{
    internal class SkydiverRepository : AbstractFolderRepository, ISkydiverRepository
    {
        public List<Skydiver> GetAll()
        {
            var skydiverFiles = Directory.GetFiles(_repositoryFolderPath, "*.skydiver");
            return skydiverFiles
                .Select(path => JsonConvert.DeserializeObject<Skydiver>(File.ReadAllText(path)))
                .ToList(); 
        }

        public void Add(Skydiver skydiver)
        {
            var filePath = Path.Combine(_repositoryFolderPath, $"{skydiver.LastName}.{skydiver.FirstName}.skydiver");

            if (File.Exists(filePath))
                throw new FreeflyAcademyException($"{skydiver.LastName} {skydiver.FirstName} existe déjà.");

            File.WriteAllText(filePath, JsonConvert.SerializeObject(skydiver));
        }
        
        public Skydiver Get(string firstName, string lastName)
        {
            var filePath = Path.Combine(_repositoryFolderPath, $"{lastName}.{firstName}.skydiver");

            if (!File.Exists(filePath))
                throw new FreeflyAcademyException($"{lastName} {firstName} n'éxiste pas.");

            return JsonConvert.DeserializeObject<Skydiver>(File.ReadAllText(filePath));
        }
    }
}