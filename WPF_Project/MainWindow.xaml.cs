using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Project.Widoki;
using Interfaces;
using Entities;
using Repositories;

namespace WPF_Project
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRepository<AlbumSet> album)
        {
            InitializeComponent();

            _album = album;
            //Test.Content = album.Get().Result.FirstOrDefault().Name;
            /*

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
           windowScreen.NavigationService.Navigate(new StartWindow());*/
        }

        private void Aaa_Click(object sender, RoutedEventArgs e)
        {
            Test.Content = _album.Get().FirstOrDefault().Name;
        }

        private readonly IRepository<AlbumSet> _album;
    }
}
