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
    /// Logika interakcji dla klasy CreateAuthorPage.xaml
    /// </summary>
    public partial class CreateAuthorPage : Page
    {
        private Window _context;
        public CreateAuthorPage(Window context)
        {
            InitializeComponent();
            _context = context;
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            string authorname = AuthorNameBox.Text.ToString();
            string authorBirth = AuthorBirthDate.Text.ToString();

            AuthorSet author = new AuthorSet();
            author.Name = authorname;
            author.Date = authorBirth;

            RepositoryWorkUnit.Instance.Authors.Insert(author);

            _context.Close();
        }

        private void ReturnFromDialogButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Close();
        }
    }
}
