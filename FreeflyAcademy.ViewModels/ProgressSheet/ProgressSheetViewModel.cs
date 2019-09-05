using AutoMapper;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using FreeflyAcademy.ViewModels.Contracts.SkydiverList;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class ProgressSheetViewModel : BaseViewModel, IProgressSheetViewModel
    {
        private readonly IProgressSheetService _progressSheetService;

        public ProgressSheetViewModel(IKernel kernel, IMapper mapper, IProgressSheetService progressSheetService) : base(kernel, mapper)
        {
            _progressSheetService = progressSheetService;

            TrackProgressSheetViewModel = _kernel.Get<ITrackProgressSheetViewModel>();
            HeadUpProgressSheetViewModel = _kernel.Get<IHeadUpProgressSheetViewModel>();
            HeadDownProgressSheetViewModel = _kernel.Get<IHeadDownProgressSheetViewModel>();
        }

        public ISkydiverViewModel SkydiverViewModel { get; private set; }

        private ITrackProgressSheetViewModel _trackProgressSheetViewModel;
        private IHeadUpProgressSheetViewModel _headUpProgressSheetViewModel;
        private IHeadDownProgressSheetViewModel _headDownProgressSheetViewModel;

        public ITrackProgressSheetViewModel TrackProgressSheetViewModel
        {
            get => _trackProgressSheetViewModel;
            set
            {
                _trackProgressSheetViewModel = value;
                OnPropertyChanged(nameof(TrackProgressSheetViewModel));
            }
        }
        public IHeadUpProgressSheetViewModel HeadUpProgressSheetViewModel
        {
            get => _headUpProgressSheetViewModel;
            set
            {
                _headUpProgressSheetViewModel = value;
                OnPropertyChanged(nameof(_headUpProgressSheetViewModel));
            }
        }
        public IHeadDownProgressSheetViewModel HeadDownProgressSheetViewModel
        {
            get => _headDownProgressSheetViewModel;
            set
            {
                _headDownProgressSheetViewModel = value;
                OnPropertyChanged(nameof(HeadDownProgressSheetViewModel));
            }
        }

        public void Load(ISkydiverTileViewModel tile)
        {
            Load(tile.FirstName, tile.LastName);
        }
        public void Load(string firstName, string lastName)
        {
            var progressSheetDto = _progressSheetService.GetOrCreate(firstName, lastName);

            SkydiverViewModel = _kernel.Get<ISkydiverViewModel>().Initialize(firstName, lastName);
            TrackProgressSheetViewModel.Initialize(firstName, lastName, progressSheetDto);
            HeadUpProgressSheetViewModel.Initialize(firstName, lastName, progressSheetDto);
            HeadDownProgressSheetViewModel.Initialize(firstName, lastName, progressSheetDto);
        }

        public void OnFileDrop(string[] filepaths)
        {
            SkydiverViewModel.AddFiles(filepaths);
        }
    }
}