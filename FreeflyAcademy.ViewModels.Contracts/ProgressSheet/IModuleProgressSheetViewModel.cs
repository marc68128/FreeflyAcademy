using FreeflyAcademy.Dtos;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Contracts.ProgressSheet
{
    public interface IModuleProgressSheetViewModel : IBaseViewModel
    {
        void Initialize(string firstName, string lastName, ProgressSheetDto progressSheet);
    }
}
