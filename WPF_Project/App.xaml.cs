using Autofac;
using Common;
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
        public App()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            Globalization.Language.Culture = culture;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            SendChangeSkin(SkinEnum.Default);
        }

        public void SendChangeSkin(SkinEnum skin)
        {
            _skin.Change(skin, Resources);
            if (mainWindow == null)
                mainWindow = new MainWindow();
            else
            {
                MainWindow window = new MainWindow();
                mainWindow.Close();
                mainWindow = window;
            }
            mainWindow.Show();
        }

        private MainWindow mainWindow;
        public Skin _skin = new Skin();

        private readonly Container container = new Container();
    }
}
