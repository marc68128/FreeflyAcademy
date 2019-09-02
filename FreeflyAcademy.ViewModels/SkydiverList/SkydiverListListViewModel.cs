using System.Collections.Generic;
using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FreeflyAcademy.Dtos;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.CreateSkydiver;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels
{
    internal class SkydiverListListViewModel : BaseViewModel, ISkydiverListViewModel
    {
        private readonly IKernel _kernel;
        private readonly ISkydiverService _skydiversService;
        private List<ISkydiverTileViewModel> _skydivers; 

        public SkydiverListListViewModel(IKernel _kernel, ISkydiverService skydiversService)
        {
            this._kernel = _kernel;
            _skydiversService = skydiversService;

            InitSkydivers();
            InitCommands();

            this.PropertyChanged += OnPropertyChanged;
        }

        private string _searchText;
        
        public ObservableCollection<ISkydiverTileViewModel> FilteredSkydiverTiles { get; set; }
        public ICommand AddSkydiverCommand { get; private set; }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }
        
        private void InitSkydivers()
        {
            _skydivers = _skydiversService.GetAll().Select(dto =>
            {
                var viewModel = _kernel.Get<ISkydiverTileViewModel>();
                viewModel.FirstName = dto.FirstName;
                viewModel.LastName = dto.LastName;
                return viewModel;
            }).ToList(); 

            FilteredSkydiverTiles = new ObservableCollection<ISkydiverTileViewModel>(_skydivers);
        }

        private void InitCommands()
        {
            AddSkydiverCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<IBaseViewModel>(_kernel.Get<ICreateSkydiverViewModel>());
            });
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchText))
            {
                FilteredSkydiverTiles.Clear();
                foreach (var skydiverTileViewModel in _skydivers.Where(t => $"{t.LastName} {t.FirstName}".Contains(SearchText)))
                {
                    FilteredSkydiverTiles.Add(skydiverTileViewModel);
                }
            }

        }
    }
}
