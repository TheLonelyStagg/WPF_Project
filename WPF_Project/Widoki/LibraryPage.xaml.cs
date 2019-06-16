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
using System.Globalization;

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

            /*
            listView.ItemsSource = RepositoryWorkUnit.Instance.Albums.Get();
            
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("AuthorSets",new AuthorsNamesValueConverter());
            view.GroupDescriptions.Add(groupDescription);
            */

            InitializeSourceItems();

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

        private void CreateAlbum_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(2);
            creationWindow.ShowDialog();

            InitializeSourceItems();
        }

        private void EditAlbum_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //AlbumSet album = (AlbumSet)listView.SelectedItem;
            KeyValuePair<string, AlbumSet> pair = (KeyValuePair<string, AlbumSet>)listView.SelectedItem;
            AlbumSet album = pair.Value;

            CreateWindow creationWindow = new CreateWindow(2, album);
            creationWindow.ShowDialog();

            InitializeSourceItems();
        }

        public void InitializeSourceItems()
        {
            listView.ItemsSource = RepositoryWorkUnit.Instance.Albums.Get()
                                           .SelectMany(
                                                ctc => ctc.AuthorSets.Select(
                                                   grp => new KeyValuePair<string, AlbumSet>(grp.Name, ctc))).ToList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Key");
            view.Filter = AlbumFilter;
            view.GroupDescriptions.Add(groupDescription);
        }

        private bool AlbumFilter(object item)
        {
            KeyValuePair<string, AlbumSet> pair = (KeyValuePair<string, AlbumSet>)item;
            AlbumSet album = pair.Value;
            if(String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
            {
                if(album.Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }

                List<AuthorSet> authors = album.AuthorSets.ToList();
                foreach(AuthorSet autor in authors)
                {
                    if(autor.Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
                List<GenreSet> genres = album.GenreSets.ToList();
                foreach(GenreSet genre in genres)
                {
                    if(genre.GenreName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }
    }

    public class AuthorsNamesValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Join(", ", ((HashSet<AuthorSet>)value).Select(x => x.Name));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class GenresValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Join(", ", ((HashSet<GenreSet>)value).Select(x => x.GenreName));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColumnsWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double.Parse(value.ToString()) / (int.Parse(parameter.ToString())));
            return (double.Parse(value.ToString()) * (int.Parse(parameter.ToString()))/100.0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
