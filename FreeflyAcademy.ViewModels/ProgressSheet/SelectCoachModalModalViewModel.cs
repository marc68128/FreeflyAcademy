using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class SelectCoachModalModalViewModel : BaseViewModel, ISelectCoachModalViewModel
    {
        public SelectCoachModalModalViewModel(IKernel kernel, ICoachService coachService)
        {
            Coaches = coachService.GetAll().Select(dto =>
            {
                var viewModel = kernel.Get<ICoachTileViewModel>();
                viewModel.FirstName = dto.FirstName;
                viewModel.LastName = dto.LastName;
                return viewModel;
            }).ToList();

            InitCommands();
        }

        public event EventHandler<ICoachTileViewModel> CoachSelected;

        public ICommand ValidateCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public List<ICoachTileViewModel> Coaches { get; }
        public ICoachTileViewModel SelectedCoach { get; set; }

        private void InitCommands()
        {
            ValidateCommand = new RelayCommand(() =>
            {
                CoachSelected?.Invoke(this, SelectedCoach);
                Messenger.Default.Send<IModalViewModel>(null);
            }, () => SelectedCoach != null);

            CancelCommand =  new RelayCommand(() => Messenger.Default.Send<IModalViewModel>(null));
        }
    }
}