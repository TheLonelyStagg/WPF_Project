using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WPF_Project.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public int x;

        public ListPage()
        {
            InitializeComponent();
        }

        public ListPage(IEnumerable<int> pageIDs)
        {
            InitializeComponent();

            foreach(var pageID in pageIDs)
            {
                tabControl.Items.Add(getTabItemOf(pageID));
            }

        }

        private void Print_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (tabControl == null || tabControl.Items.Count == 0)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Gratulacje, drukujesz!", "Congratulation", MessageBoxButton.OK, MessageBoxImage.Information);
            e.Handled = true;
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

        private TabItem getTabItemOf(int pageID)
        {
            TabItem tabItem = new TabItem();

            ListView listView = new ListView();
            listView.SelectionChanged += ListView_SelectionChanged;

            GridView gridView = new GridView();

            listView.ItemsSource = RepositoryWorkUnit.Instance.AlbumCollections.Get(pageID).CollectionRecordSets;

            gridView.Columns.Add(new GridViewColumn() { Header = "Num.", Width = 70, DisplayMemberBinding = new Binding("Id") }); 
            gridView.Columns.Add(new GridViewColumn() { Header = "Autor", Width = 150, DisplayMemberBinding = new Binding("AlbumSet.AuthorSets") { Converter = new AuthorsNamesValueConverter() } });
            gridView.Columns.Add(new GridViewColumn() { Header = "Tytuł", Width = 200, DisplayMemberBinding = new Binding("AlbumSet.Name") });
            gridView.Columns.Add(new GridViewColumn() { Header = "Nośnik", Width = 150, DisplayMemberBinding = new Binding("FormatSet.FormatName") });

            listView.View = gridView;

            tabItem.Header = RepositoryWorkUnit.Instance.AlbumCollections.Get(pageID).CollectionName;
            tabItem.Content = listView;

            return tabItem;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            menuItem_position.IsEnabled = true;
            int howManySelected = ((ListView)((TabItem)tabControl.SelectedItem).Content).SelectedItems.Count;
            if (howManySelected > 0)
            {
                if (howManySelected == 1)
                {
                    menuItemItem_openInLib.IsEnabled = true;
                    menuItemItem_edit.IsEnabled = true;
                }
                else
                {
                    menuItemItem_openInLib.IsEnabled = false;
                    menuItemItem_edit.IsEnabled = false;
                }
                menuItemItem_delete.IsEnabled = true;
            }
            else
            {
                menuItemItem_openInLib.IsEnabled = false;
                menuItemItem_edit.IsEnabled = false;
                menuItemItem_delete.IsEnabled = false;
            }
        }

        private void SaveList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseList_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Are u sure, and so on
            //      Sejwiki

            tabControl.Items.RemoveAt(tabControl.SelectedIndex);
            
        }

        private void DeleteList_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Are u sure, and so on

            tabControl.Items.RemoveAt(tabControl.SelectedIndex);

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tabControl.Items.Count >0)
            {
                menuItem_position.IsEnabled = true;
            }
            else
                menuItem_position.IsEnabled = false;
        }
    }
}
