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
using Interfaces;
using Entities;
using Repositories;
using System.Diagnostics;
using WPF_Project.OknaDodwania;

namespace WPF_Project.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        public LibraryPage()
        {
            InitializeComponent();
        }

        private void CreateAuthor_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(1);
            creationWindow.ShowDialog();
        }

        private void EditAuthor_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //na razie bierzemy jakikolwiek obiekt z bazy
            //trzeba będzie zmienić to na wybrany z listy
            var author = RepositoryWorkUnit.Instance.Authors.Get().FirstOrDefault();
            CreateWindow creationWindow = new CreateWindow(1, author);
            creationWindow.ShowDialog();
        }

        private void CreateAlbum_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(2);
            creationWindow.ShowDialog();
        }

        private void EditAlbum_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var album = RepositoryWorkUnit.Instance.Albums.Get().FirstOrDefault();
            CreateWindow creationWindow = new CreateWindow(2, album);
            creationWindow.ShowDialog();
        }

        private void CreateFormat_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(3);
            creationWindow.ShowDialog();
        }

        private void EditFormat_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var format = RepositoryWorkUnit.Instance.Formats.Get().FirstOrDefault();
            CreateWindow creationWindow = new CreateWindow(3, format);
            creationWindow.ShowDialog();
        }

        private void CreateGenre_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(4);
            creationWindow.ShowDialog();
        }

        private void EditGenre_MenuItwm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
