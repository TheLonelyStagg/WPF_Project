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
    /// Logika interakcji dla klasy CreateGenrePage.xaml
    /// </summary>
    public partial class CreateGenrePage : Page
    {
        private Window _context;
        private bool isEdit;
        private GenreSet _genre;

        public CreateGenrePage(Window context, GenreSet genre = null)
        {
            InitializeComponent();

            _context = context;
            
            if(genre != null)
            {
                GenreNameBox.Text = genre.GenreName;
                isEdit = true;
                _genre = genre;

                genreTopLabel.Content = "Edytuj gatunek";
                AddGenreButton.Content = "Edytuj";
            }
        }

        private void AddGenreButton_Click(object sender, RoutedEventArgs e)
        {
            string genrename = GenreNameBox.Text.ToString();

            var message = ValidationClass.validateStringTextbox(genrename);
            if(!message.Item1)
            {
                MessageBox.Show(message.Item2);
                return;
            }
            if(isEdit)
            {
                var genre = RepositoryWorkUnit.Instance.Genres.Get().FirstOrDefault(x => x.Id == _genre.Id);

                genre.GenreName = genrename;

                RepositoryWorkUnit.Instance.Genres.Update(genre, genre.Id);
            }
            else
            {
                GenreSet genre = new GenreSet();
                genre.GenreName = genrename;

                RepositoryWorkUnit.Instance.Genres.Insert(genre);
            }

            _context.Close();
        }

        private void ReturnFromDialogButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Close();
        }
    }
}
