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
            ChangeSkin(Skin.Nightmod);
            using (var scope = container.Get.BeginLifetimeScope())
            {
                MainWindow mainWindow = container.Get.Resolve<MainWindow>();
                mainWindow.Show();
            }
            
        }

        public void ChangeSkin(Skin Skin)
        {
            Resources.Clear();
            Resources.MergedDictionaries.Clear();
            if (Skin == Skin.Default)
                ApplyResources("/Styles;component/Default.xaml");
            else if (Skin == Skin.Nightmod)
                ApplyResources("/Styles;component/NightMod.xaml");
            ApplyResources("/Styles;component/Shared.xaml");
        }

        private void ApplyResources(string src)
        {
            var dict = new ResourceDictionary() { Source = new Uri(src, UriKind.Relative) };
            foreach (var mergeDict in dict.MergedDictionaries)
            {
                Resources.MergedDictionaries.Add(mergeDict);
            }

            foreach (var key in dict.Keys)
            {
                Resources[key] = dict[key];
            }
        }

        private readonly Container container = new Container();
    }
}
