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

namespace WPF_Project.OknaDodwania.WidokiDodawania
{
    /// <summary>
    /// Logika interakcji dla klasy CreateCollectionListPage.xaml
    /// </summary>
    public partial class CreateCollectionListPage : Page
    {
        private Window _context;
        private bool isEdit;
        private AlbumCollectionSet _albumCollection;
        

        public CreateCollectionListPage(Window context, AlbumCollectionSet albumColection = null)
        {
            InitializeComponent();
            _context = context;
           
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Close();
        }

        private void AddCollectionBtn_Click(object sender, RoutedEventArgs e)
        {
            string collectionFileName = collectionFileNameBox.Text.ToString();
            string collectionDesc = collectionDescBox.Text.ToString();
            string collectionName = collectionNameBox.Text.ToString();

            AlbumCollectionSet collection = new AlbumCollectionSet();

            collection.CollectionName = collectionName;
            collection.Description = collectionDesc;
            collection.FileName = collectionFileName;
            collection.CreationDate = DateTime.Now.Year.ToString();

            RepositoryWorkUnit.Instance.AlbumCollections.Insert(collection);

            _context.DialogResult = true;
        }
    }
}
