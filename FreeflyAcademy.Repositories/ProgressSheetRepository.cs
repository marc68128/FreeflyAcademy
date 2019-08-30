using FreeflyAcademy.Domain;
using FreeflyAcademy.Repositories.Contracts;
using Newtonsoft.Json;
using System.IO;

namespace FreeflyAcademy.Repositories
{
    internal class ProgressSheetRepository : AbstractFolderRepository, IProgressSheetRepository
    {
        public ProgressSheet GetOrCreate(string firstName, string lastName)
        {
            var filePath = Path.Combine(_repositoryFolderPath, $"{lastName}.{firstName}.progressSheet");

            if (File.Exists(filePath))
            {
                return JsonConvert.DeserializeObject<ProgressSheet>(File.ReadAllText(filePath));
            }

            return new ProgressSheet();
        }

        public void Save(string firstName, string lastName, ProgressSheet progressSheet)
        {
            var filePath = Path.Combine(_repositoryFolderPath, $"{lastName}.{firstName}.progressSheet");

            File.WriteAllText(filePath, JsonConvert.SerializeObject(progressSheet));
        }
    }
}
