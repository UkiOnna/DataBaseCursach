using AuctionInterface.DataPages.AuctionPages;
using AuctionInterface.DataPages.Client;
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

namespace AuctionInterface
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private Window _window;
        public MainMenu(Window window)
        {
            InitializeComponent();
            _window = window;
        }

        private void ShowClientPage(object sender, RoutedEventArgs e)
        {
            _window.Content = new ClientPage(_window);
        }

        private void ShowAuctionPage(object sender, RoutedEventArgs e)
        {
            _window.Content = new AuctionPage(_window);
        }
    }
}
