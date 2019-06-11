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
using WPF_Project.OknaList;

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

        private void AuthorHeader_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EntitiesListWindow listWindow = new EntitiesListWindow(1);
            listWindow.ShowDialog();
        }

        private void FormatHeader_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EntitiesListWindow listWindow = new EntitiesListWindow(2);
            listWindow.ShowDialog();
        }

        private void GenreHeader_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EntitiesListWindow listWindow = new EntitiesListWindow(3);
            listWindow.ShowDialog();
        }
    }
}
