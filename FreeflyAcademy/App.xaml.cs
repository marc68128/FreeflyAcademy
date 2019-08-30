using System;
using System.Configuration;
using System.IO;
using FreeflyAcademy.ViewModels;
using System.Windows;
using FreeflyAcademy.Repositories;
using FreeflyAcademy.Services;
using Ninject;

namespace FreeflyAcademy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _iocKernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _iocKernel = new StandardKernel();
            _iocKernel.Load(new RepositoryModule());
            _iocKernel.Load(new ServiceModule());
            _iocKernel.Load(new ViewModelModule());

            Current.MainWindow = _iocKernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
