using FreeflyAcademy.Dtos;

namespace FreeflyAcademy.Services.Contracts
{
    public interface IProgressSheetService
    {
        ProgressSheetDto GetOrCreate(string firstName, string lastName);
    }
}
