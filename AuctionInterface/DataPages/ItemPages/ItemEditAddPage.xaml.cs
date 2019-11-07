using AuctionInterface.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для ItemEditAddPage.xaml
    /// </summary>
    public partial class ItemEditAddPage : Page
    {
        Window _window;
        int _id;
        List<string> data = new List<string>();
        public ItemEditAddPage(Window window)
        {
            InitializeComponent();
            _window = window;
            using (var context = new AuctionContext())
            {
                foreach (var client in context.Clients)
                {
                    buyer.Items.Add(client.Name);
                    seller.Items.Add(client.Name);
                }

                foreach (var auction in context.Auctions)
                {
                    this.auction.Items.Add(auction.Name);
                }
            }
        }
        public ItemEditAddPage(int sellerId, int? buyerId, int? auctionId, int id, Window window)
        {
            InitializeComponent();
            create.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Visible;
            _window = window;
            using (var context = new AuctionContext())
            {
                foreach (var client in context.Clients)
                {
                    buyer.Items.Add(client.Name);
                    seller.Items.Add(client.Name);
                }

                foreach (var auction in context.Auctions)
                {
                    this.auction.Items.Add(auction.Name);
                }

                Item item = context.Items.SingleOrDefault(p => p.Id == id);
                this.name.Text = item.Name;
                this.startPrice.Text = item.StartPrice.ToString();
                this.endPrice.Text = item.EndPrice.ToString();
                this.description.Text = item.Description;
                try
                {
                    this.auction.SelectedItem = context.Auctions.SingleOrDefault(p => p.Id == auctionId).Name;
                    this.buyer.SelectedItem = context.Clients.SingleOrDefault(p => p.Id == buyerId).Name;
                }
                catch (Exception) { }
                this.seller.SelectedItem = context.Clients.SingleOrDefault(p => p.Id == sellerId).Name;

                this.lotNumber.Text = item.LotNumber.ToString();
            }
            _id = id;
        }

        private bool IsDataFill()
        {
            data.AddRange(new List<string> { name.Text, startPrice.Text, description.Text, seller.SelectedItem.ToString(), lotNumber.Text });
            foreach (var str in data)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
            }
            return true;
        }

        private void Create(object sender, RoutedEventArgs e)
        {

            if (IsDataFill())
            {
                using (var context = new AuctionContext())
                {
                    try
                    {
                        Item item = new Item() { EndPrice = null, BuyerId = null, AuctionId = null };
                        if (!string.IsNullOrEmpty(endPrice.Text) && buyer.SelectedItem != null)
                        {
                            item.EndPrice = int.Parse(endPrice.Text);
                            item.BuyerId = context.Clients.SingleOrDefault(p => p.Name == buyer.SelectedItem.ToString()).Id;
                        }
                        else if (auction.SelectedItem != null)
                        {
                            item.AuctionId = context.Auctions.SingleOrDefault(p => p.Name == auction.SelectedItem.ToString()).Id;
                        }
                        item.Name = name.Text;
                        item.Description = description.Text;
                        item.StartPrice = int.Parse(startPrice.Text);
                        item.SellerId = context.Clients.SingleOrDefault(p => p.Name == seller.SelectedItem.ToString()).Id;
                        item.LotNumber = int.Parse(lotNumber.Text);
                        context.Items.Add(item);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("HOW????");
                    }

                    context.SaveChanges();
                }
                MessageBox.Show("Added");
                _window.Content = new ItemPage(_window);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
                data.Clear();
            }

        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            if (IsDataFill())
            {
                using (var context = new AuctionContext())
                {
                    Item item = context.Items.SingleOrDefault(p => p.Id == _id);
                    if (!string.IsNullOrEmpty(endPrice.Text) && buyer.SelectedItem != null)
                    {
                        item.EndPrice = int.Parse(endPrice.Text);
                        item.BuyerId = context.Clients.SingleOrDefault(p => p.Name == buyer.SelectedItem.ToString()).Id;
                    }
                    if (auction.SelectedItem != null)
                    {
                        item.AuctionId = context.Auctions.SingleOrDefault(p => p.Name == auction.SelectedItem.ToString()).Id;
                    }
                    item.Name = name.Text;
                    item.Description = description.Text;
                    item.StartPrice = int.Parse(startPrice.Text);
                    item.SellerId = context.Clients.SingleOrDefault(p => p.Name == seller.SelectedItem.ToString()).Id;
                    item.LotNumber = int.Parse(lotNumber.Text);
                    context.SaveChanges();
                }
                MessageBox.Show("Edited");
                _window.Content = new ItemPage(_window);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _window.Content = new ItemPage(_window);
        }


    }
}