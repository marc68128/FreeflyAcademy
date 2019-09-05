using FreeflyAcademy.Dtos;

namespace FreeflyAcademy.Services.Contracts.Business
{
    public interface IProgressSheetService
    {
        ProgressSheetDto GetOrCreate(string firstName, string lastName);
        void Save(string firstName, string lastName, ProgressSheetDto progressSheetDto);
        void Save(string firstName, string lastName, TrackProgressSheetDto trackProgressSheetDto);
        void Save(string firstName, string lastName, HeadUpProgressSheetDto headUpProgressSheetDto);
        void Save(string firstName, string lastName, HeadDownProgressSheetDto headDownProgressSheetDto);
    }
}
