using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class CoachTileViewModel : BaseViewModel, ICoachTileViewModel
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
    }
}
