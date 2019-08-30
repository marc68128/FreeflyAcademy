using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Contracts.Base;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class SelectCoachModalViewModel : BaseViewModel, ISelectCoachModalViewModel
    {
        private readonly IKernel _kernel;
        private readonly ICoachService _coachService;

        private ICoachTileViewModel _selectedCoach;
        private string _password;

        public SelectCoachModalViewModel(IKernel kernel, ICoachService coachService)
        {
            _kernel = kernel;
            _coachService = coachService;

            Coaches = _coachService.GetAll().Select(dto =>
            {
                var viewModel = _kernel.Get<ICoachTileViewModel>();
                viewModel.FirstName = dto.FirstName;
                viewModel.LastName = dto.LastName;
                return viewModel;
            }).ToList();

            InitCommands();
        }

        public event EventHandler<ICoachTileViewModel> CoachSelected;
        public event EventHandler Cancel;

        public ICommand ValidateCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

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

        private void InitCommands()
        {
            ValidateCommand = new RelayCommand(() =>
            {
                var dbPassword = _coachService.GetAll()
                    .Single(c => c.FirstName == SelectedCoach.FirstName && c.LastName == SelectedCoach.LastName)
                    .Md5Password;

                if (dbPassword != CalculateMD5Hash(Password))
                {
                    var infoModal = _kernel.Get<IModalInfoViewModel>();
                    infoModal.Title = "Erreur  !";
                    infoModal.Content = $"Le mot de passe saisi est incorrect.";
                    Messenger.Default.Send<IModalViewModel>(infoModal);
                    Cancel?.Invoke(this, EventArgs.Empty);
                    return;
                }

                CoachSelected?.Invoke(this, SelectedCoach);
                Messenger.Default.Send<IModalViewModel>(null);
            }, () => !string.IsNullOrWhiteSpace(Password) && Password.Length > 3 && SelectedCoach != null);

            CancelCommand = new RelayCommand(() =>
            {
                Cancel?.Invoke(this, EventArgs.Empty);
                Messenger.Default.Send<IModalViewModel>(null);
            });
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
