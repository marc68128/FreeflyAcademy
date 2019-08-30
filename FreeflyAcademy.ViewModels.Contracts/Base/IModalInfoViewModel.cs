using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreeflyAcademy.ViewModels.Contracts.Base
{
    public interface IModalInfoViewModel : IModalViewModel 
    {
        string Title { get; set; }
        string Content { get; set; }
        ICommand OkCommand { get; }
    }
}
