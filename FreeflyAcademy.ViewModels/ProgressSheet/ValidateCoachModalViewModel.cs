using AutoMapper;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.Services.Contracts.Technical;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class ValidateCoachModalViewModel : BaseViewModel, IValidateCoachModalViewModel
    {
        private readonly IHashService _hashService;
        private readonly ICoachService _coachService;

        private ICoachTileViewModel _selectedCoach;
        private string _password;

        public ValidateCoachModalViewModel(IKernel kernel, IMapper mapper, IHashService hashService, ICoachService coachService) : base(kernel, mapper)
        {
            _hashService = hashService;
            _coachService = coachService;

            Coaches = coachService
                .GetAll()
                .Select(dto => _mapper.Map(dto, _kernel.Get<ICoachTileViewModel>()))
                .ToList();

            InitCommands();
        }

        public event EventHandler<ICoachTileViewModel> CoachSelected;
        public event EventHandler Cancel;


        public List<ICoachTileViewModel> Coaches { get; }
        public ICoachTileViewModel SelectedCoach
        {
            get => _selectedCoach;
            set
            {
                _selectedCoach = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

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
            var dbPassword = _coachService.GetAll()
                .Single(c => c.FirstName == SelectedCoach.FirstName && c.LastName == SelectedCoach.LastName)
                .Md5Password;

            if (!_hashService.IsMatching(Password, dbPassword))
            {
                ShowModal("Erreur  !", "Le mot de passe saisi est incorrect.");
                Cancel?.Invoke(this, EventArgs.Empty);
                return;
            }

            CoachSelected?.Invoke(this, SelectedCoach);
            CloseModal();
        }

        private bool CanExecuteValidateCommand()
        {
            return !string.IsNullOrWhiteSpace(Password) && Password.Length > 3 && SelectedCoach != null;
        }

        private void ExecuteCancelCommand()
        {
            Cancel?.Invoke(this, EventArgs.Empty);
            CloseModal();
        }

        #endregion

    }
}