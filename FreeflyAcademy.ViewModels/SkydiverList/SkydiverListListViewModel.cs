using FreeflyAcademy.Services.Contracts;
using FreeflyAcademy.ViewModels.Contracts;
using System.Collections.ObjectModel;
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

        public SkydiverListListViewModel(IKernel _kernel, ISkydiverService skydiversService)
        {
            this._kernel = _kernel;
            _skydiversService = skydiversService;
            InitSkydivers();
            InitCommands();
        }


        public ObservableCollection<ISkydiverTileViewModel> SkydiverTiles { get; set; }
        public ICommand AddSkydiverCommand { get; private set; }

        private void InitSkydivers()
        {
            SkydiverTiles = new ObservableCollection<ISkydiverTileViewModel>(_skydiversService.GetAll().Select(dto =>
            {
                var viewModel = _kernel.Get<ISkydiverTileViewModel>();
                viewModel.FirstName = dto.FirstName;
                viewModel.LastName = dto.LastName;
                return viewModel; 
            }));
        }

        private void InitCommands()
        {
            AddSkydiverCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<IBaseViewModel>(_kernel.Get<ICreateSkydiverViewModel>());
            });
        }
    }
}
