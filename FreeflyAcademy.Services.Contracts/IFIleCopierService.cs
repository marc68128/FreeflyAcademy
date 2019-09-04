using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeflyAcademy.Services.Contracts
{
    public interface IFileCopierService
    {
        Task Copy(string source, string dest, IProgress<double> progress = null);
    }
}
