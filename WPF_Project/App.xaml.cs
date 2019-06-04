using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Project
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (var scope = container.Get.BeginLifetimeScope())
            {
                MainWindow mainWindow = container.Get.Resolve<MainWindow>();
                mainWindow.Show();
            }
        }

        private readonly Container container = new Container();
    }
}
