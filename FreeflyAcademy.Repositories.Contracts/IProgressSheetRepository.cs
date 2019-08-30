using FreeflyAcademy.Domain;

namespace FreeflyAcademy.Repositories.Contracts
{
    public interface IProgressSheetRepository
    {
        ProgressSheet GetOrCreate(string firstName, string lastName);
        void Save(string firstName, string lastName, ProgressSheet progressSheet);
    }
}