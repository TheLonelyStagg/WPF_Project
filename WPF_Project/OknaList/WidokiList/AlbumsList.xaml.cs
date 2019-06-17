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
using WPF_Project.OknaDodwania;
using WPF_Project.OknaList;
using System.Globalization;
using Entities;

namespace WPF_Project.OknaList.WidokiList
{
    /// <summary>
    /// Logika interakcji dla klasy AlbumsList.xaml
    /// </summary>
    public partial class AlbumsList : Window
    {
        public int Id { get; set; }
        public AlbumsList()
        {
            InitializeComponent();
            InitializeSourceItems();
        }

        public void InitializeSourceItems()
        {
            albumListView.ItemsSource = RepositoryWorkUnit.Instance.Albums.Get()
                                           .SelectMany(
                                                ctc => ctc.AuthorSets.Select(
                                                   grp => new KeyValuePair<string, AlbumSet>(grp.Name, ctc))).ToList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(albumListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Key");
            view.Filter = AlbumFilter;
            view.GroupDescriptions.Add(groupDescription);
        }

        private bool AlbumFilter(object item)
        {
            KeyValuePair<string, AlbumSet> pair = (KeyValuePair<string, AlbumSet>)item;
            AlbumSet album = pair.Value;
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
            {
                if (album.Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }

                List<AuthorSet> authors = album.AuthorSets.ToList();
                foreach (AuthorSet autor in authors)
                {
                    if (autor.Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
                List<GenreSet> genres = album.GenreSets.ToList();
                foreach (GenreSet genre in genres)
                {
                    if (genre.GenreName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(albumListView.ItemsSource).Refresh();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AlbumSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            if (albumListView.SelectedItems.Count > 0)
            {
                KeyValuePair<string, AlbumSet> selectedItem = (KeyValuePair<string, AlbumSet>)albumListView.SelectedItem;
                AlbumSet album = selectedItem.Value;
                this.Id = album.Id;
                this.Close();
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
                return ((double.Parse(value.ToString()) - 12) * (int.Parse(parameter.ToString())) / 100.0);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }

}