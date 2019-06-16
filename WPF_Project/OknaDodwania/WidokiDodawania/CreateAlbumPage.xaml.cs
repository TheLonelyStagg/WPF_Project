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
using Xceed.Wpf.Toolkit;
using Entities;

namespace WPF_Project.OknaDodwania.WidokiDodawania
{
    /// <summary>
    /// Logika interakcji dla klasy CreateAlbumPage.xaml
    /// </summary>
    public partial class CreateAlbumPage : Page
    {
        private Window _context;
        private bool isEdit;
        private AlbumSet _album;

        public CreateAlbumPage(Window context, AlbumSet album = null)
        {
            InitializeComponent();
            _context = context;

            albumAuthorsComboBox.DisplayMemberPath = "Name";
            albumAuthorsComboBox.ValueMemberPath = "Id";
            albumAuthorsComboBox.ItemsSource = RepositoryWorkUnit.Instance.Authors.Get();

            albumGenresComboBox.DisplayMemberPath = "GenreName";
            albumGenresComboBox.ValueMemberPath = "Id";
            albumGenresComboBox.ItemsSource = RepositoryWorkUnit.Instance.Genres.Get();


            if(album != null)
            {
                albumTopLabel.Content = "Edytuj album";
                addAlbumButton.Content = "Edytuj";

                ObservableCollection<AuthorSet> albumObservable = new ObservableCollection<AuthorSet>();
                foreach(AuthorSet item in album.AuthorSets)
                {
                    albumObservable.Add(item);
                }

                ObservableCollection<GenreSet> genreObservable = new ObservableCollection<GenreSet>();
                foreach (GenreSet item in album.GenreSets)
                {
                    genreObservable.Add(item);
                }

                albumAuthorsComboBox.SelectedItemsOverride = albumObservable;
                albumGenresComboBox.SelectedItemsOverride = genreObservable;


                albumDescriptionBox.Text = album.Description;
                albumNameTextBox.Text = album.Name;
                albumRealaseDateBox.Text = album.ReleaseDate;

                isEdit = true;
                _album = album;
            }

        }

        private void AddAlbumButton_Click(object sender, RoutedEventArgs e)
        {

            string albumname = albumNameTextBox.Text.ToString();
            string albumdesc = albumDescriptionBox.Text.ToString();
            string albumrealase = albumRealaseDateBox.Text.ToString();

            var message = ValidationClass.validateStringTextbox(albumname);
            if (!message.Item1)
            {
                System.Windows.MessageBox.Show(message.Item2);
                return;
            }

            message = ValidationClass.validateStringTextbox(albumdesc);
            if (!message.Item1)
            {
                System.Windows.MessageBox.Show(message.Item2);
                return;
            }

            message = ValidationClass.validateDateTextbox(albumrealase);
            if (!message.Item1)
            {
                System.Windows.MessageBox.Show(message.Item2);
                return;
            }
            if(albumAuthorsComboBox.SelectedItems.Count < 1 || albumGenresComboBox.SelectedItems.Count < 1)
            {
                System.Windows.MessageBox.Show("Album musi posiadać autorów lub gatunki !!!");
                return;
            }
            if (isEdit)
            {
                var album = RepositoryWorkUnit.Instance.Albums.Get().FirstOrDefault(x => x.Id == _album.Id);

                album.Name = albumname;
                album.Description = albumdesc;
                album.ReleaseDate = albumrealase;

                album.AuthorSets.Clear();
                album.GenreSets.Clear();

                foreach (var author in albumAuthorsComboBox.SelectedItems)
                {
                    AuthorSet _author = (AuthorSet)author;
                    album.AuthorSets.Add(_author);
                }

                foreach (var genre in albumGenresComboBox.SelectedItems)
                {
                    GenreSet _genre = (GenreSet)genre;
                    album.GenreSets.Add(_genre);
                }

                RepositoryWorkUnit.Instance.Albums.Update(album, album.Id);
            }
            else
            {
                AlbumSet album = new AlbumSet();

                album.Name = albumname;
                album.Description = albumdesc;
                album.ReleaseDate = albumrealase;
                //narazie nie mamy url i chyba nie będziemy mieli
                album.ImgUrl = " ";

                foreach(var author in albumAuthorsComboBox.SelectedItems)
                {
                    AuthorSet _author = (AuthorSet)author;
                    album.AuthorSets.Add(_author);
                }

                foreach(var genre in albumGenresComboBox.SelectedItems)
                {
                    GenreSet _genre = (GenreSet)genre;
                    album.GenreSets.Add(_genre);
                }

                RepositoryWorkUnit.Instance.Albums.Insert(album);
            }
            _context.Close();
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Close();
        }
    }
}
