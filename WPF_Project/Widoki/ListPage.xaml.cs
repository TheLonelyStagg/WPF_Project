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

namespace WPF_Project.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            tabControl.Items.Add(getTabItemOf("kappa"));
        }

        public ListPage(IEnumerable<int> pageIDs)
        {
            InitializeComponent();

            foreach(var pageID in pageIDs)
            {

            }


            tabControl.Items.Add(getTabItemOf("kappa"));
        }

        private TabItem getTabItemOf(string header)
        {
            TabItem tabItem = new TabItem();

            ListView listView = new ListView();

            GridView gridView = new GridView();

            gridView.Columns.Add(new GridViewColumn() { Header = "Num.", Width = 70 }); //Bindingi
            gridView.Columns.Add(new GridViewColumn() { Header = "Autor", Width = 150 });
            gridView.Columns.Add(new GridViewColumn() { Header = "Tytuł", Width = 200 });
            gridView.Columns.Add(new GridViewColumn() { Header = "Nośnik", Width = 150 });
            gridView.Columns.Add(new GridViewColumn() { Header = "Ilość", Width = 200 });

            listView.View = gridView;

            tabItem.Header = header;
            tabItem.Content = listView;

            return tabItem;
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

        
    }
}
