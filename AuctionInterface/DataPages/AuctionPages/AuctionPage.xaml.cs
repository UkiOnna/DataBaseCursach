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
using AuctionInterface.Models;

namespace AuctionInterface.DataPages.AuctionPages
{
    /// <summary>
    /// Логика взаимодействия для AuctionPage.xaml
    /// </summary>
    public partial class AuctionPage : Page
    {
        Window _window;
        int _id;
        public AuctionPage(Window window)
        {
            InitializeComponent();
            _window = window;
            List<Models.Auction> auctions = new List<Models.Auction>();
            using (var context = new AuctionContext())
            {
                for (int i = 0; i < context.Auctions.Count(); i++)
                {
                    auctions.Add(new Models.Auction() { Adress = context.Auctions.ToList()[i].Adress, Name = context.Auctions.ToList()[i].Name,
                        Id = context.Auctions.ToList()[i].Id,AuctionDate= context.Auctions.ToList()[i].AuctionDate,Specify= context.Auctions.ToList()[i].Specify });

                }
            }
            table.ItemsSource = auctions;
        }
        void ShowAddPage(object sender, RoutedEventArgs e)
        {
            _window.Content = new AuctionEditAdd(_window);
        }

        void ShowEditPage(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem != null)
            {
                Models.Auction auction = (Models.Auction)table.SelectedItem;
                _window.Content = new AuctionEditAdd(auction.Name, auction.Adress,auction.AuctionDate,auction.Specify, auction.Id, _window);
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem != null)
            {
                Models.Auction auction = (Models.Auction)table.SelectedItem;
                using (var context = new AuctionContext())
                {
                    context.Auctions.Remove(context.Auctions.SingleOrDefault(p => p.Id == auction.Id));
                    context.SaveChanges();
                }
                MessageBox.Show("Deleted");
                _window.Content = new MainMenu(_window);
            }
            else
            {
                MessageBox.Show("Строка не выбрана");
            }
        }

        void BackToMainMenu(object sender, RoutedEventArgs e)
        {
            _window.Content = new MainMenu(_window);
        }
    }
}
