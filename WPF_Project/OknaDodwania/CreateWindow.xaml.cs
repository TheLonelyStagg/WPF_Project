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
using WPF_Project.OknaDodwania.WidokiDodawania;
using Entities;

namespace WPF_Project.OknaDodwania
{
    /// <summary>
    /// Logika interakcji dla klasy CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        private Object _entity;
        private int _id;

        public CreateWindow(int widok, object entity = null)
        {
            InitializeComponent();
            _entity = entity;
            switch (widok)
            {
                //tworzenie autorów
                case 1:
                    Loaded += CreateUser_Page;
                    break;
                //tworzenie albumów
                case 2:
                    Loaded += CreateAlbum_Page;
                    break;
                //tworzenie wydań
                case 3:
                    Loaded += CreateFormat_Page;
                    break;
                //tworzenie gatunków
                case 4:
                    Loaded += CreateGenre_Page;
                    break;
                //tworzenie listy kolekcji
                case 5:
                    Loaded += CreateCollectionList_Page;
                    break;
                //tworzenie rekordu listy
                case 6:
                    Loaded += CreateCollectionRecord_Page;
                    break;
            }
        }

        private void CreateUser_Page(object sender, RoutedEventArgs e)
        {
            //wysyłam tutaj this (context) żeby potem w page była możliwość zamknięcia tego okna
            //jak ktoś zna lepsze sposoby to zapraszam do ulepszenia

            //obiekt idzie do edycji
            if(_entity != null)
            {
                windowScreen.NavigationService.Navigate(new CreateAuthorPage(this,(AuthorSet)_entity));
            }
            //tworzenie
            else
            {
                windowScreen.NavigationService.Navigate(new CreateAuthorPage(this));
            }          
        }

        private void CreateFormat_Page(object sender, RoutedEventArgs e)
        {
            //wysyłam tutaj this (context) żeby potem w page była możliwość zamknięcia tego okna
            //jak ktoś zna lepsze sposoby to zapraszam do ulepszenia

            //obiekt idzie do edycji
            if (_entity != null)
            {
                windowScreen.NavigationService.Navigate(new CreateFormatPage(this, (FormatSet)_entity));
            }
            //tworzenie
            else
            {
                windowScreen.NavigationService.Navigate(new CreateFormatPage(this));
            }
        }

        private void CreateGenre_Page(object sender, RoutedEventArgs e)
        {
            //wysyłam tutaj this (context) żeby potem w page była możliwość zamknięcia tego okna
            //jak ktoś zna lepsze sposoby to zapraszam do ulepszenia

            //obiekt idzie do edycji
            if (_entity != null)
            {
                windowScreen.NavigationService.Navigate(new CreateGenrePage(this, (GenreSet)_entity));
            }
            //tworzenie
            else
            {
                windowScreen.NavigationService.Navigate(new CreateGenrePage(this));
            }
        }

        private void CreateAlbum_Page(object sender, RoutedEventArgs e)
        {
            //wysyłam tutaj this (context) żeby potem w page była możliwość zamknięcia tego okna
            //jak ktoś zna lepsze sposoby to zapraszam do ulepszenia

            //obiekt idzie do edycji
            if (_entity != null)
            {
                windowScreen.NavigationService.Navigate(new CreateAlbumPage(this, (AlbumSet)_entity));
            }
            //tworzenie
            else
            {
                windowScreen.NavigationService.Navigate(new CreateAlbumPage(this));
            }
        }

        private void CreateCollectionList_Page(object sender, RoutedEventArgs e)
        {
            //wysyłam tutaj this (context) żeby potem w page była możliwość zamknięcia tego okna
            //jak ktoś zna lepsze sposoby to zapraszam do ulepszenia

            //obiekt idzie do edycji
            if (_entity != null)
            {
                windowScreen.NavigationService.Navigate(new CreateCollectionListPage(this, (AlbumCollectionSet)_entity));
            }
            //tworzenie
            else
            {
                windowScreen.NavigationService.Navigate(new CreateCollectionListPage(this));
            }
        }

        private void CreateCollectionRecord_Page(object sender, RoutedEventArgs e)
        {
            windowScreen.NavigationService.Navigate(new CreateCollectionRecordPage(this));
        }
    }
}
