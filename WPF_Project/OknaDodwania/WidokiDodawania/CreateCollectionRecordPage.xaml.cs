using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPF_Project.OknaList.WidokiList;

namespace WPF_Project.OknaDodwania.WidokiDodawania
{
    /// <summary>
    /// Logika interakcji dla klasy CreateCollectionRecordPage.xaml
    /// </summary>
    public partial class CreateCollectionRecordPage : Page
    {
        private Window _context;
        private AlbumSet _album;


        public CreateCollectionRecordPage(Window context)
        {
            InitializeComponent();
            _context = context;

            collectionRecordFormatType.DisplayMemberPath = "FormatName";
            collectionRecordFormatType.ValueMemberPath = "Id";
            collectionRecordFormatType.ItemsSource = RepositoryWorkUnit.Instance.Formats.Get();
        }

        private void ChooseAlbumBtn_Click(object sender, RoutedEventArgs e)
        {
            AlbumsList albumList = new AlbumsList();
            albumList.ShowDialog();
            int id = albumList.Id;

            AlbumSet album = RepositoryWorkUnit.Instance.Albums.Get().FirstOrDefault(x => x.Id == id);
            choosedAlbumName.Content = "" + album.Name + " ";
            _album = album;
        }

        private void AddRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_album == null)
            {
                MessageBox.Show("Musisz wybrać album!");
                return;
            }

            if(collectionRecordFormatType.SelectedItems.Count < 1)
            {
                MessageBox.Show("Muisz wybrać format wydania!");
                return;
            }
            if (collectionRecordFormatType.SelectedItems.Count > 1)
            {
                MessageBox.Show("Możesz wybrać tylko jeden format!");
                return;
            }

            CollectionRecordSet newRecord = new CollectionRecordSet();

            newRecord.AlbumId = _album.Id;
            newRecord.AlbumSet = _album;
            newRecord.AlbumCollectionId = 1;

            foreach (var format in collectionRecordFormatType.SelectedItems)
            {
                FormatSet _format = (FormatSet)format;
                newRecord.FormatId = _format.Id;
                newRecord.FormatSet = _format;
            }

            RepositoryWorkUnit.Instance.CollectionRecords.Insert(newRecord);
            _context.Close();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Close();
        }

        private void CollectionRecordFormatType_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            if (collectionRecordFormatType.SelectedItems.Count > 1)
            {
                MessageBox.Show("Możesz wybrać tylko jeden format!");
            }
        }
    }
}
