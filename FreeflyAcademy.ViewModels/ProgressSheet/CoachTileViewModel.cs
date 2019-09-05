using AutoMapper;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class CoachTileViewModel : BaseViewModel, ICoachTileViewModel
    {
        private string _firstName;
        private string _lastName;

        public CoachTileViewModel(IKernel kernel, IMapper mapper) : base(kernel, mapper)
        {
        }

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