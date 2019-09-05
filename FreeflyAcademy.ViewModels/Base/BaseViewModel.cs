using System.ComponentModel;
using System.Runtime.CompilerServices;
using AutoMapper;
using FreeflyAcademy.ViewModels.Annotations;
using FreeflyAcademy.ViewModels.Contracts.Base;
using GalaSoft.MvvmLight.Messaging;
using Ninject;

namespace FreeflyAcademy.ViewModels.Base
{
    internal abstract class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        protected readonly IKernel _kernel;
        protected readonly IMapper _mapper;

        protected BaseViewModel(IKernel kernel, IMapper mapper)
        {
            _kernel = kernel;
            _mapper = mapper;
        }

        protected void ShowModal(string title, string content)
        {
            var infoModal = _kernel.Get<IModalInfoViewModel>();
            infoModal.Title = title;
            infoModal.Content = content;
            Messenger.Default.Send<IModalViewModel>(infoModal);
        }

        protected void CloseModal()
        {
            Messenger.Default.Send<IModalViewModel>(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}