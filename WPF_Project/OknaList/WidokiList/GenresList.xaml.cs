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
using WPF_Project.OknaDodwania;
using Entities;

namespace WPF_Project.OknaList.WidokiList
{
    /// <summary>
    /// Logika interakcji dla klasy GenresList.xaml
    /// </summary>
    public partial class GenresList : Page
    {
        public GenresList(Window Context)
        {
            InitializeComponent();

            genresListView.ItemsSource = RepositoryWorkUnit.Instance.Genres.Get();
        }

        private void GenresListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (genresListView.SelectedItems.Count > 0)
            {
                editGenreBtn.IsEnabled = true;
                removeGenreBtn.IsEnabled = true;
            }
            else
            {
                editGenreBtn.IsEnabled = false;
                removeGenreBtn.IsEnabled = false;
            }
        }

        private void CreateNewGenre_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(4);
            creationWindow.ShowDialog();

            genresListView.ItemsSource = RepositoryWorkUnit.Instance.Genres.Get();
        }

        private void EditGenreBtn_Click(object sender, RoutedEventArgs e)
        {
            GenreSet genre = (GenreSet)genresListView.SelectedItem;
            CreateWindow creationWindow = new CreateWindow(4,genre);
            creationWindow.ShowDialog();

            genresListView.ItemsSource = RepositoryWorkUnit.Instance.Genres.Get();
        }

        private void RemoveGenreBtn_Click(object sender, RoutedEventArgs e)
        {
            GenreSet genre = (GenreSet)genresListView.SelectedItem;
            RepositoryWorkUnit.Instance.Genres.Delete(genre);
            RepositoryWorkUnit.Instance.Complete();

            genresListView.ItemsSource = RepositoryWorkUnit.Instance.Genres.Get();
        }
    }
}
