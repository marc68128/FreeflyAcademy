using System.Configuration;

namespace FreeflyAcademy.Repositories
{
    internal abstract class AbstractFolderRepository
    {
        protected readonly string _repositoryFolderPath;

        protected AbstractFolderRepository()
        {
            _repositoryFolderPath = ConfigurationManager.AppSettings["RepositoryFolder"];
        }
    }
}
