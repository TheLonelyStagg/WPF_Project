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
using System.Windows.Shapes;
using WPF_Project.OknaDodwania.WidokiDodawania;

namespace WPF_Project.OknaDodwania
{
    /// <summary>
    /// Logika interakcji dla klasy CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow(int widok)
        {
            InitializeComponent();

            switch (widok)
            {
                case 1:
                    Loaded += CreateUser_Page;
                    break;

            }

        }

        private void CreateUser_Page(object sender, RoutedEventArgs e)
        {
            //wysyłam tutaj this (context) żeby potem w page była możliwość zamknięcia tego okna
            //jak ktoś zna lepsze sposoby to zapraszam do ulepszenia
            windowScreen.NavigationService.Navigate(new CreateAuthorPage(this));
        }
    }
}
