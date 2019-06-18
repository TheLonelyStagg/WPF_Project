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
using Common;
using Entities;
using Interfaces;
using Repositories;

namespace WPF_Project.Widoki
{
    /// <summary>
    /// Logika interakcji dla klasy StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Page
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void LibraryButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LibraryPage());
        }

        private void ListMenuButton_OnClcik(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListMenuPage());
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current)._skin.skin == SkinEnum.Default)
            {
                ((App)Application.Current).SendChangeSkin(SkinEnum.Nightmod);
            }
            else
            {
                ((App)Application.Current).SendChangeSkin(SkinEnum.Default);
            }

            //Application.Current.MainWindow.Close();
        }
    }
}
