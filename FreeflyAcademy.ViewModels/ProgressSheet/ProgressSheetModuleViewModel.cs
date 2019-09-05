using FreeflyAcademy.Dtos;
using FreeflyAcademy.Enums;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using GalaSoft.MvvmLight.Messaging;
using Ninject;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AutoMapper;
using FreeflyAcademy.Services.Contracts.Business;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal abstract class ProgressSheetModuleViewModel<TProgressSheetModuleDto> : BaseViewModel, IModuleProgressSheetViewModel
        where TProgressSheetModuleDto : ProgressSheetModuleDto
    {
        protected readonly IProgressSheetService _progressSheetService;

        protected string FirstName, LastName;

        private bool _validated;
        private DateTime? _validationDate;
        private string _coach;

        protected ProgressSheetModuleViewModel(IKernel kernel, IMapper mapper, IProgressSheetService progressSheetService) : base(kernel, mapper)
        {
            _progressSheetService = progressSheetService;
        }

        protected void Initialize(string firstName, string lastName)
        {
            Initialize(firstName, lastName, _progressSheetService.GetOrCreate(firstName, lastName));
        }

        public abstract void Initialize(string firstName, string lastName, ProgressSheetDto progressSheet);
        public abstract TProgressSheetModuleDto GetProgressSheetDto();

        protected abstract void Save();


        public bool Validated
        {
            get => _validated;
            set
            {
                if (_validated == false && value)
                    _validated = true;
                OnPropertyChanged();
            }
        }
        public DateTime? ValidationDate
        {
            get => _validationDate;
            set
            {
                _validationDate = value;
                OnPropertyChanged();
            }
        }
        public string Coach
        {
            get => _coach;
            set
            {
                _coach = value;
                OnPropertyChanged();
            }
        }

        protected void ProgressSheetViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Validated))
            {
                foreach (var acquisitionLevelProperty in GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(p => p.FieldType == typeof(AcquisitionLevel)))
                {
                    acquisitionLevelProperty.SetValue(sender, AcquisitionLevel.Acquired);
                }
            }

            if (IsAcquisitionLevelProperty(e.PropertyName) || e.PropertyName == nameof(Validated))
            {
                var selectCoachModal = _kernel.Get<IValidateCoachModalViewModel>();
                selectCoachModal.CoachSelected += (o, model) =>
                {
                    if (IsValidated())
                    {
                        _validationDate = DateTime.Now;
                        _validated = true;
                        _coach = $"{model.FirstName} {model.LastName}";
                    }
                    else
                    {
                        _validationDate = null;
                        _validated = false;
                        _coach = null;
                    }
                    Save();
                    Initialize(FirstName, LastName);
                };
                selectCoachModal.Cancel += (o, model) =>
                {
                    Initialize(FirstName, LastName);
                };
                Messenger.Default.Send<IModalViewModel>(selectCoachModal);
            }
        }

        private bool IsAcquisitionLevelProperty(string propertyName)
        {
            return GetType().GetProperty(propertyName)?.PropertyType == typeof(AcquisitionLevel);
        }

        private bool IsValidated()
        {
            foreach (var acquisitionLevelProperty in GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(p => p.FieldType == typeof(AcquisitionLevel)))
            {
                if ((AcquisitionLevel)acquisitionLevelProperty.GetValue(this) != AcquisitionLevel.Acquired)
                    return false;
            }
            return true;
        }
    }
}
