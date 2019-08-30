using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreeflyAcademy.ViewModels.Contracts
{
    public interface ISkydiverTileViewModel : IBaseViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        ICommand OpenCommand { get; }
    }
}
