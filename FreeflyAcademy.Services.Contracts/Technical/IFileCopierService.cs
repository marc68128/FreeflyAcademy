using System;
using System.Threading.Tasks;

namespace FreeflyAcademy.Services.Contracts.Technical
{
    public interface IFileCopierService
    {
        Task Copy(string source, string dest, IProgress<double> progress = null);
    }
}
