using FreeflyAcademy.ViewModels.Base;
using FreeflyAcademy.ViewModels.Contracts.ProgressSheet;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using FreeflyAcademy.Services.Contracts.Business;
using FreeflyAcademy.Services.Contracts.Technical;
using FreeflyAcademy.ViewModels.Contracts.Base;
using FreeflyAcademy.ViewModels.Contracts.EditSkydiver;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.ProgressSheet
{
    internal class SkydiverViewModel : BaseViewModel, ISkydiverViewModel
    {
        private readonly ISkydiverService _skydiverService;
        private readonly IFileCopierService _fileCopierService;

        private string _firstName;
        private string _lastName;
        private string _videoDirectoryPath;
        private bool _personalRig;
        private int _jumpsCount;
        private DateTime? _skydiveStartingDate;
        private DateTime? _freeflyStartingDate;
        private string _selectedSubFolder = "Track";
        private bool _isLoading;

        public SkydiverViewModel(IKernel kernel, IMapper mapper, ISkydiverService skydiverService, IFileCopierService fileCopierService) : base(kernel, mapper)
        {
            _skydiverService = skydiverService;
            _fileCopierService = fileCopierService;

            Files = new ObservableCollection<IFileViewModel>();

            InitCommands();
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
        public string VideoDirectoryPath
        {
            get => _videoDirectoryPath;
            set
            {
                _videoDirectoryPath = value;
                OnPropertyChanged(nameof(VideoDirectoryPath));
            }
        }
        public bool PersonalRig
        {
            get => _personalRig;
            set
            {
                _personalRig = value;
                OnPropertyChanged(nameof(PersonalRig));
            }
        }
        public int JumpsCount
        {
            get => _jumpsCount;
            set
            {
                _jumpsCount = value;
                OnPropertyChanged(nameof(JumpsCount));
            }
        }
        public DateTime? SkydiveStartingDate
        {
            get => _skydiveStartingDate;
            set
            {
                _skydiveStartingDate = value;
                OnPropertyChanged(nameof(SkydiveStartingDate));
            }
        }
        public DateTime? FreeflyStartingDate
        {
            get => _freeflyStartingDate;
            set
            {
                _freeflyStartingDate = value;
                OnPropertyChanged(nameof(FreeflyStartingDate));
            }
        }
        public string SelectedSubFolder
        {
            private get => _selectedSubFolder;
            set
            {
                _selectedSubFolder = value;
                InitFiles();
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IFileViewModel> Files { get; }

        public ICommand OpenFolderCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        
        public ISkydiverViewModel Initialize(string firstName, string lastName)
        {
            var skydiverDto = _skydiverService.Get(firstName, lastName);

            FirstName = skydiverDto.FirstName;
            LastName = skydiverDto.LastName;
            VideoDirectoryPath = skydiverDto.VideoDirectoryPath;
            FreeflyStartingDate = skydiverDto.FreeflyStartingDate;
            JumpsCount = skydiverDto.JumpsCount;
            SkydiveStartingDate = skydiverDto.SkydiveStartingDate;
            PersonalRig = skydiverDto.PersonalRig;

            InitFiles();

            return this;
        }

        public void AddFiles(string[] filePaths)
        {
            if (string.IsNullOrWhiteSpace(VideoDirectoryPath))
            {
                var infoModal = _kernel.Get<IModalInfoViewModel>();
                infoModal.Title = "Attention  !";
                infoModal.Content = $"Le dossier vidéo de {FirstName} {LastName} n'a pas été configuré.\n" +
                                    $"Vous ne pouvez pas ajouter de vidéos.";
                Messenger.Default.Send<IModalViewModel>(infoModal);
                return;
            }

            if (!Directory.Exists(VideoDirectoryPath))
            {
                var infoModal = _kernel.Get<IModalInfoViewModel>();
                infoModal.Title = "Attention  !";
                infoModal.Content = $"Le dossier \"{VideoDirectoryPath}\" configuré pour {FirstName} {LastName} n'éxiste pas.\n" +
                                    $"Veuillez le corriger afin de pouvoir ajouter des vidéos.";
                Messenger.Default.Send<IModalViewModel>(infoModal);
                return;
            }

            var pathIncludingSubFolder = Path.Combine(VideoDirectoryPath, SelectedSubFolder);

            if (!Directory.Exists(pathIncludingSubFolder))
                Directory.CreateDirectory(pathIncludingSubFolder);

            var selectCoachModal = _kernel.Get<ISelectCoachModalViewModel>();
            selectCoachModal.CoachSelected += async (sender, model) =>
            {
                IsLoading = true;
                foreach (var filepath in filePaths)
                {
                    var newFilePath = Path.Combine(pathIncludingSubFolder, $"{model.FirstName} {model.LastName}{Path.GetExtension(filepath)}");
                    int incr = 1;
                    while (File.Exists(newFilePath))
                    {
                        newFilePath = Path.Combine(pathIncludingSubFolder, $"{model.FirstName} {model.LastName} ({incr++}){Path.GetExtension(filepath)}");
                    }
                    await _fileCopierService.Copy(filepath, newFilePath);

                    this.Initialize(FirstName, LastName);
                }
                IsLoading = false;
            };
            Messenger.Default.Send<IModalViewModel>(selectCoachModal);
        }

        private void InitCommands()
        {
            OpenFolderCommand = new RelayCommand(() => Process.Start("explorer", VideoDirectoryPath), () => Directory.Exists(VideoDirectoryPath));
            EditCommand = new RelayCommand(() => Messenger.Default.Send<IModalViewModel>(_kernel.Get<IEditSkydiverModalViewModel>().Initialize(FirstName, LastName)));
        }

        private void InitFiles()
        {
            if (!string.IsNullOrWhiteSpace(VideoDirectoryPath))
            {
                Files.Clear();

                if (Directory.Exists(VideoDirectoryPath))
                {
                    if (!string.IsNullOrWhiteSpace(SelectedSubFolder))
                    {
                        var videoDirectoryPathWithSubFolder = Path.Combine(VideoDirectoryPath, SelectedSubFolder);
                        if (Directory.Exists(videoDirectoryPathWithSubFolder))
                        {
                            Directory.GetFiles(videoDirectoryPathWithSubFolder)
                                .OrderByDescending(File.GetCreationTime)
                                .Select(path => _kernel.Get<IFileViewModel>().Initialize(path)).ToList()
                                .ForEach(fileViewModel => Files.Add(fileViewModel));
                        }
                    }
                    else
                    {
                        Directory.GetFiles(VideoDirectoryPath)
                            .OrderByDescending(File.GetCreationTime)
                            .Select(path => _kernel.Get<IFileViewModel>().Initialize(path)).ToList()
                            .ForEach(fileViewModel => Files.Add(fileViewModel));
                    }
                }
            }
        }
    }
}