using Entities;
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

namespace WPF_Project.OknaDodwania.WidokiDodawania
{
    /// <summary>
    /// Logika interakcji dla klasy CreateOpenCollectionPage.xaml
    /// </summary>
    public partial class CreateOpenCollectionPage : Page
    {
        private CreateWindow _context;
        public List<int> indexesChosen;

        public CreateOpenCollectionPage(CreateWindow context)
        {
            InitializeComponent();

            _context = context;
            indexesChosen = _context.additionalVariable as List<int>;
            listView.ItemsSource = RepositoryWorkUnit.Instance.AlbumCollections.Get().Where(x => !indexesChosen.Contains(x.Id));
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = RepositoryWorkUnit.Instance.AlbumCollections.Get().Where(x=> !indexesChosen.Contains(x.Id));
        }

        private void Btn_Open_Click(object sender, RoutedEventArgs e)
        {
            
            List<int> indexesList = new List<int>();

            foreach (AlbumCollectionSet position in listView.SelectedItems)
            {
                indexesList.Add(position.Id);
            }
            _context.additionalVariable = indexesList;
            _context.DialogResult = true;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                btn_Open.IsEnabled = true;
            }
            else
            {
                btn_Open.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _context.Close();
        }
    }
}
