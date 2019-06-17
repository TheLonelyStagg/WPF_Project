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
using WPF_Project.OknaDodwania;

namespace WPF_Project.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public int x;
        public TextBox textbox13;

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
            //Zapytaj o zapis

            PrintList();
            e.Handled = true;
        }

        private FlowDocument CreateDoc ()
        {
            
            FlowDocument doc = new FlowDocument();
        
            Table table1 = new Table();

            doc.Blocks.Add(table1);

            doc.ColumnWidth = 999999;

            int cols = 4;

            for(int c = 0; c<cols; c++)
            {
                table1.Columns.Add(new TableColumn());
                table1.Columns[c].Width = new GridLength(260);
            }

            table1.Columns[0].Width = new GridLength(50);

            table1.RowGroups.Add(new TableRowGroup());

            table1.RowGroups[0].Rows.Add(new TableRow());

            TableRow currentRow = table1.RowGroups[0].Rows[0];
            currentRow.Background = System.Windows.Media.Brushes.DarkGray; //Tutaj kolor nagłwokow
            currentRow.Foreground = System.Windows.Media.Brushes.White;

            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Nr."))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Autor"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Tytuł"))));
            currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Nośnik"))));



            int indx = 1;
            foreach (CollectionRecordSet rowObject in ((ListView)((TabItem)tabControl.SelectedItem).Content).ItemsSource)
            {
                table1.RowGroups[0].Rows.Add(new TableRow());

                currentRow = table1.RowGroups[0].Rows[indx];

                if( indx % 2 == 0)
                    currentRow.Background = System.Windows.Media.Brushes.White;
                else
                    currentRow.Background = System.Windows.Media.Brushes.LightGray;

                currentRow.Foreground = System.Windows.Media.Brushes.Black;

                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(indx + ""))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(
                    String.Join(", ", rowObject.AlbumSet.AuthorSets.Select(x => x.Name))
                    ))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(rowObject.AlbumSet.Name))));
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(rowObject.FormatSet.FormatName))));
                
                indx++;
            }

            return doc;
           
        }


        private void PrintList()
        {
            PrintDialog printDialog = new PrintDialog();

            FlowDocument document = CreateDoc();

            document.Name = "FlowDoc";

            IDocumentPaginatorSource idpSource = document;

            bool? result = printDialog.ShowDialog();

            if(result == true)
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");


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
            tabItem.Tag = pageID;

            ListView listView = new ListView();

            listView.SelectionChanged += ListView_SelectionChanged;

            GridView gridView = new GridView();

            listView.ItemsSource = RepositoryWorkUnit.Instance.AlbumCollections.Get(pageID).CollectionRecordSets;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Key");
            view.Filter = CollectionListFilter;


            gridView.Columns.Add(new GridViewColumn()
            {
                Header = "Num.",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn()
            {
                Header = "Autor",
                DisplayMemberBinding = new Binding("AlbumSet.AuthorSets") { Converter = new AuthorsNamesValueConverter() }
            });
            gridView.Columns.Add(new GridViewColumn()
            {
                Header = "Tytuł",
                DisplayMemberBinding = new Binding("AlbumSet.Name")
            });
            gridView.Columns.Add(new GridViewColumn()
            {
                Header = "Nośnik",
                DisplayMemberBinding = new Binding("FormatSet.FormatName")
            });

            

            BindingOperations.SetBinding(gridView.Columns[0],
                GridViewColumn.WidthProperty,
                new Binding("ActualWidth")
                {
                    ElementName = "tabControl",
                    Converter = new ColumnsWidthConverter(),
                    ConverterParameter = 5
                });

            BindingOperations.SetBinding(gridView.Columns[1],
                GridViewColumn.WidthProperty,
                new Binding("ActualWidth")
                {
                    ElementName = "tabControl",
                    Converter = new ColumnsWidthConverter(),
                    ConverterParameter = 40
                });

            BindingOperations.SetBinding(gridView.Columns[2],
                GridViewColumn.WidthProperty,
                new Binding("ActualWidth")
                {
                    ElementName = "tabControl",
                    Converter = new ColumnsWidthConverter(),
                    ConverterParameter = 35
                });

            BindingOperations.SetBinding(gridView.Columns[3],
                GridViewColumn.WidthProperty,
                new Binding("ActualWidth")
                {
                    ElementName = "tabControl",
                    Converter = new ColumnsWidthConverter(),
                    ConverterParameter = 19
                });


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

        private void CreateNewList_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(5);
            creationWindow.ShowDialog();

            if(creationWindow.DialogResult == true)
            {
                int id = RepositoryWorkUnit.Instance.AlbumCollections.Get().Select(x => x.Id).DefaultIfEmpty(0).Max();
                TabItem nowy = getTabItemOf(id);
                tabControl.Items.Add(nowy);
                nowy.Focus();

            }
            
        }

        private void MenuItemItem_add_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(6);
            creationWindow.ShowDialog();

            TabItem tab =(TabItem) tabControl.SelectedItem;

            int id = (int)tab.Tag;

            AlbumCollectionSet album = RepositoryWorkUnit.Instance.AlbumCollections.Get().FirstOrDefault(x => x.Id == id);
            int recordID = RepositoryWorkUnit.Instance.CollectionRecords.Get().Select(x => x.Id).DefaultIfEmpty(0).Max();

            CollectionRecordSet record = RepositoryWorkUnit.Instance.CollectionRecords.Get().FirstOrDefault(x => x.Id == recordID);
            record.AlbumCollectionId = album.Id;

            album.CollectionRecordSets.Add(record);

            //tutaj testowo;
            tabControl.Items.Remove(tab);

            TabItem nowy = getTabItemOf(id);
            tabControl.Items.Add(nowy);
            nowy.Focus();

        }

        private void MenuItemItem_delete_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = (TabItem)tabControl.SelectedItem;
            ListView listView = (ListView)tab.Content;

            foreach(CollectionRecordSet record in listView.SelectedItems)
            {
                RepositoryWorkUnit.Instance.CollectionRecords.Delete(record);
            }

            tabControl.Items.Remove(tab);

            TabItem nowy = getTabItemOf((int)tab.Tag);
            tabControl.Items.Add(nowy);
            nowy.Focus();
        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            TabItem tab = (TabItem)tabControl.SelectedItem;
            ListView listView = (ListView)tab.Content;

            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
        }

        private bool CollectionListFilter(object item)
        {
            CollectionRecordSet record = item as CollectionRecordSet;
            if(String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
            {
                if(record.FormatSet.FormatName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase)>= 0)
                {
                    return true;
                }
                if(record.AlbumSet.Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true;
                }

                List<AuthorSet> authors = record.AlbumSet.AuthorSets.ToList();
                foreach(AuthorSet author in authors)
                {
                    if(author.Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
