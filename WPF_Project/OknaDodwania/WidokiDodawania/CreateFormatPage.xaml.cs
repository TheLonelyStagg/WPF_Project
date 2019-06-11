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
    /// Logika interakcji dla klasy CreateFormatPage.xaml
    /// </summary>
    public partial class CreateFormatPage : Page
    {
        private Window _context;
        private bool isEdit;
        private FormatSet _format;

        public CreateFormatPage(Window context, FormatSet format = null)
        {
            InitializeComponent();
            _context = context;

            if(format != null)
            {
                FormatNameBox.Text = format.FormatName;
                isEdit = true;
                _format = format;

                formatTopLabel.Content = "Edytuj wydanie";
                AddFormatButton.Content = "Edytuj";
            }
        }

        private void AddFormatButton_Click(object sender, RoutedEventArgs e)
        {
            string formatname = FormatNameBox.Text.ToString();
            if(isEdit)
            {
                var format = RepositoryWorkUnit.Instance.Formats.Get().FirstOrDefault(x => x.Id == _format.Id);

                format.FormatName = formatname;

                RepositoryWorkUnit.Instance.Formats.Update(format, format.Id);
            }
            else
            {
                FormatSet format = new FormatSet();

                format.FormatName = formatname;
                RepositoryWorkUnit.Instance.Formats.Insert(format);
            }

            _context.Close();
        }

        private void ReturnFromDialogButton_Click(object sender, RoutedEventArgs e)
        {
            _context.Close();
        }
    }
}
