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
using WPF_Project.OknaDodwania;
using Entities;

namespace WPF_Project.OknaList.WidokiList
{
    /// <summary>
    /// Logika interakcji dla klasy FormatsList.xaml
    /// </summary>
    public partial class FormatsList : Page
    {
        public FormatsList(Window context)
        {
            InitializeComponent();
            formatListView.ItemsSource = RepositoryWorkUnit.Instance.Formats.Get();
        }

        private void FormatListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(formatListView.SelectedItems.Count >0)
            {
                editNewFormat.IsEnabled = true;
                removeFormat.IsEnabled = true;
            }
            else
            {
                editNewFormat.IsEnabled = false;
                removeFormat.IsEnabled = false;
            }
        }

        private void CreateNewFormat_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow creationWindow = new CreateWindow(3);
            creationWindow.ShowDialog();

            formatListView.ItemsSource = RepositoryWorkUnit.Instance.Formats.Get();
        }

        private void EditNewFormat_Click(object sender, RoutedEventArgs e)
        {
            FormatSet format = (FormatSet)formatListView.SelectedItem;
            CreateWindow creationWindow = new CreateWindow(3,format);
            creationWindow.ShowDialog();

            formatListView.ItemsSource = RepositoryWorkUnit.Instance.Formats.Get();
        }

        private void RemoveFormat_Click(object sender, RoutedEventArgs e)
        {
            FormatSet format = (FormatSet)formatListView.SelectedItem;

            RepositoryWorkUnit.Instance.Formats.Delete(format);
            RepositoryWorkUnit.Instance.Complete();

            formatListView.ItemsSource = RepositoryWorkUnit.Instance.Formats.Get();
        }
    }
}
