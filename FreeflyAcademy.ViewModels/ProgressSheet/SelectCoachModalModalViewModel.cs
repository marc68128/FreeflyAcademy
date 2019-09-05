using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class SelectCoachModalModalViewModel : BaseViewModel, ISelectCoachModalViewModel
    {
        public SelectCoachModalModalViewModel(IKernel kernel, IMapper mapper, ICoachService coachService) : base(kernel, mapper)
        {
            Coaches = coachService
                .GetAll()
                .Select(dto => _mapper.Map(dto, _kernel.Get<ICoachTileViewModel>()))
                .ToList();

            InitCommands();
        }

        public event EventHandler<ICoachTileViewModel> CoachSelected;
        
        public List<ICoachTileViewModel> Coaches { get; }
        public ICoachTileViewModel SelectedCoach { get; set; }

        #region Commands

        public ICommand ValidateCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        private void InitCommands()
        {
            ValidateCommand = new RelayCommand(ExecuteValidateCommand, CanExecuteValidateCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        private void ExecuteValidateCommand()
        {
            CoachSelected?.Invoke(this, SelectedCoach);
            CloseModal();
        }

        private bool CanExecuteValidateCommand()
        {
            return SelectedCoach != null;
        }

        private void ExecuteCancelCommand()
        {
            CloseModal();
        }

        #endregion
    }
}