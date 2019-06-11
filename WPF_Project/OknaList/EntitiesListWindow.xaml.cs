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
using System.Windows.Shapes;
using WPF_Project.OknaList.WidokiList;

namespace WPF_Project.OknaList
{
    /// <summary>
    /// Logika interakcji dla klasy EntitiesListWindow.xaml
    /// </summary>
    public partial class EntitiesListWindow : Window
    {
        public EntitiesListWindow(int widok)
        {
            InitializeComponent();

            switch (widok)
            {
                //lista autorów
                case 1:
                    Loaded += AuthorList_Page;
                    break;
                //lista formatów
                case 2:
                    Loaded += FormatList_Page;
                    break;
                //lista gatunków
                case 3:
                    Loaded += GenreList_Page;
                    break;
            }
        }

        private void AuthorList_Page(object sender, RoutedEventArgs e)
        {
            windowScreen.NavigationService.Navigate(new AuthorsList(this));
        }

        private void FormatList_Page(object sender, RoutedEventArgs e)
        {
            windowScreen.NavigationService.Navigate(new FormatsList(this));
        }

        private void GenreList_Page(object sender, RoutedEventArgs e)
        {
            windowScreen.NavigationService.Navigate(new GenresList(this));
        }
    }
}
