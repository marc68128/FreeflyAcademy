using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.CreateSkydiver;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.SkydiverList
{
    internal class SkydiverListViewModel : BaseViewModel, ISkydiverListViewModel
    {
        private readonly ISkydiverService _skydiversService;
        private List<ISkydiverTileViewModel> _skydivers; 

        private string _searchText;

        public SkydiverListViewModel(IKernel kernel, IMapper mapper, ISkydiverService skydiversService) : base(kernel, mapper)
        {
            _skydiversService = skydiversService;

            InitSkydivers();
            InitCommands();

            this.PropertyChanged += OnPropertyChanged;
        }

        
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
            _skydivers = _skydiversService.GetAll().Select(dto => _mapper.Map(dto, _kernel.Get<ISkydiverTileViewModel>())).ToList(); 
            FilteredSkydiverTiles = new ObservableCollection<ISkydiverTileViewModel>(_skydivers);
        }

        private void InitCommands()
        {
            AddSkydiverCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<IModalViewModel>(_kernel.Get<ICreateSkydiverModalViewModel>());
            });
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchText))
            {
                FilteredSkydiverTiles.Clear();
                foreach (var skydiverTileViewModel in _skydivers.Where(t => $"{t.LastName} {t.FirstName}".Contains(SearchText) || $"{t.FirstName} {t.LastName}".Contains(SearchText)))
                {
                    FilteredSkydiverTiles.Add(skydiverTileViewModel);
                }
            }

        }
    }
}
