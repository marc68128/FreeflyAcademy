using System.ComponentModel;
using System.Runtime.CompilerServices;
using FreeflyAcademy.ViewModels.Annotations;
using FreeflyAcademy.ViewModels.Contracts.Base;

namespace FreeflyAcademy.ViewModels.Base
{
    internal class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
