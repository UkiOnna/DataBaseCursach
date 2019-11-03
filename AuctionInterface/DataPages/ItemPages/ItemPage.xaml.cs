using AuctionInterface.CustomModels;
using AuctionInterface.DataPages.AuctionPages;
using AuctionInterface.Models;
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

namespace AuctionInterface.DataPages.ItemPages
{
    /// <summary>
    /// Логика взаимодействия для ItemPage.xaml
    /// </summary>
    public partial class ItemPage : Page
    {
        Window _window;
        public ItemPage(Window window)
        {
            InitializeComponent();
            _window = window;
            List<CustomItem> items = new List<CustomItem>();
            using (var context = new AuctionContext())
            {
                for (int i = 0; i < context.Items.Count(); i++)
                {
                    CustomItem item = new CustomItem();
                    item.Buyer = "";
                    item.Auction = "";
                    item.StartPrice = context.Items.ToList()[i].StartPrice;
                    item.Name = context.Items.ToList()[i].Name;
                    item.EndPrice = context.Items.ToList()[i].EndPrice;
                    item.Description = context.Items.ToList()[i].Description;
                    item.SellerId = context.Items.ToList()[i].SellerId;
                    item.BuyerId = context.Items.ToList()[i].BuyerId;
                    item.AuctionId = context.Items.ToList()[i].AuctionId;
                    item.LotNumber = context.Items.ToList()[i].LotNumber;
                    if (context.Items.ToList()[i].BuyerId != null)
                    {
                        var buyer = context.Clients.FirstOrDefault(u => u.Id == item.BuyerId);
                        item.Buyer = buyer.Name;
                    }

                    if (context.Items.ToList()[i].AuctionId != null)
                    {
                        var auction = context.Auctions.FirstOrDefault(u => u.Id == item.AuctionId);
                        item.Auction = auction.Name;
                    }
                    item.Id = context.Items.ToList()[i].Id;
                    var seller = context.Clients.FirstOrDefault(u => u.Id == item.SellerId);
                    item.Seller = seller.Name;

                    items.Add(item);
                }
            }
            table.ItemsSource = items;
        }

        public ItemPage(int auctionId, Window window)
        {
            InitializeComponent();
            _window = window;
            List<CustomItem> items = new List<CustomItem>();
            using (var context = new AuctionContext())
            {
                foreach (var a in context.Items.Where(a => a.AuctionId == auctionId).ToList())
                {
                    CustomItem item = new CustomItem();
                    item.Buyer = "";
                    item.Auction = "";
                    item.StartPrice = a.StartPrice;
                    item.Name = a.Name;
                    item.EndPrice = a.EndPrice;
                    item.Description = a.Description;
                    item.SellerId = a.SellerId;
                    item.BuyerId = a.BuyerId;
                    item.AuctionId = a.AuctionId;
                    item.LotNumber = a.LotNumber;
                    if (a.BuyerId != null)
                    {
                        var buyer = context.Clients.FirstOrDefault(u => u.Id == item.BuyerId);
                        item.Buyer = buyer.Name;
                    }

                    if (a.AuctionId != null)
                    {
                        var auction = context.Auctions.FirstOrDefault(u => u.Id == item.AuctionId);
                        item.Auction = auction.Name;
                    }
                    item.Id = a.Id;
                    var seller = context.Clients.FirstOrDefault(u => u.Id == item.SellerId);
                    item.Seller = seller.Name;

                    items.Add(item);
                }
            }
            addButton.Visibility = Visibility.Hidden;
            editButton.Visibility = Visibility.Hidden;
            deleteButton.Visibility = Visibility.Hidden;
            backButton.Click += BackToAuctions;
            table.ItemsSource = items;
        }

        void ShowAddPage(object sender, RoutedEventArgs e)
        {
            _window.Content = new ItemEditAddPage(_window);
        }

        void ShowEditPage(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem != null)
            {
                CustomItem item = (CustomItem)table.SelectedItem;
                _window.Content = new ItemEditAddPage(item.SellerId, item.BuyerId, item.AuctionId, item.Id, _window);
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
                CustomItem item = (CustomItem)table.SelectedItem;
                using (var context = new AuctionContext())
                {
                    context.Items.Remove(context.Items.SingleOrDefault(p => p.Id == item.Id));
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

        void BackToAuctions(object sender, RoutedEventArgs e)
        {
            _window.Content = new AuctionPage(_window);
        }
    }
}
