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
using System.ComponentModel;

namespace WPF_Project.OknaList.WidokiList
{
    /// <summary>
    /// Logika interakcji dla klasy AuthorsList.xaml
    /// </summary>
    public partial class AuthorsList : Page
    {
        public AuthorsList(Window context)
        {
            InitializeComponent();

            authorListView.ItemsSource = RepositoryWorkUnit.Instance.Authors.Get();    
        }

        private void AuthorListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(authorListView.SelectedItems.Count > 0)
            {
                editAuthorBtn.IsEnabled = true;
                removeAuthorBtn.IsEnabled = true;
            }
            else
            {
                editAuthorBtn.IsEnabled = false;
                removeAuthorBtn.IsEnabled = false;
            }
        }

        private void CreateAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(1);
            creationWindow.ShowDialog();

            authorListView.ItemsSource = RepositoryWorkUnit.Instance.Authors.Get();

        }

        private void EditAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorSet author = (AuthorSet)authorListView.SelectedItem;
            CreateWindow creationWindow = new CreateWindow(1,author);
            creationWindow.ShowDialog();

            authorListView.ItemsSource = RepositoryWorkUnit.Instance.Authors.Get();
        }

        private void RemoveAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorSet author = (AuthorSet)authorListView.SelectedItem;
            RepositoryWorkUnit.Instance.Authors.Delete(author);
            RepositoryWorkUnit.Instance.Complete();

            authorListView.ItemsSource = RepositoryWorkUnit.Instance.Authors.Get();

        }
    }
}
