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
using Entities;
using Interfaces;
using Repositories;

namespace WPF_Project.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy ListMenuPage.xaml
    /// </summary>
    public partial class ListMenuPage : Page
    {
        public ListMenuPage()
        {
            InitializeComponent();
            listView.ItemsSource = RepositoryWorkUnit.Instance.AlbumCollections.Get();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                btn_Open.IsEnabled = true;
                btn_Delete.IsEnabled = true;
            }
            else
            {
                btn_Open.IsEnabled = false;
                btn_Delete.IsEnabled = false;
            }
        }

        private void Btn_Open_Click(object sender, RoutedEventArgs e)
        {
            List<int> indexesList = new List<int>();

            foreach(AlbumCollectionSet position in listView.SelectedItems)
            {
                indexesList.Add(position.Id);
            }

            this.NavigationService.Navigate(new ListPage(indexesList));
        }
    }
}
