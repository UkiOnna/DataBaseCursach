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
        }
        public ItemEditAddPage(string name, int startPrice, int? endPrice, string description, int sellerId, int? buyerId, int id, Window window)
        {
            InitializeComponent();
            create.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Visible;
            _window = window;
            this.name.Text = name;
            this.startPrice.Text = startPrice.ToString();
            this.endPrice.Text = endPrice.ToString();
            this.description.Text = description;
            this.sellerId.Text = sellerId.ToString();
            this.buyerId.Text = buyerId.ToString();
            _id = id;
        }

        private bool IsDataFill()
        {
            data.AddRange(new List<string> { name.Text, startPrice.Text, description.Text, sellerId.Text });
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
                        Item item = new Item() { EndPrice = null, BuyerId = null };
                        if (!string.IsNullOrEmpty(endPrice.Text) && !string.IsNullOrEmpty(buyerId.Text))
                        {
                            item.EndPrice = int.Parse(endPrice.Text);
                            item.BuyerId = int.Parse(buyerId.Text);
                        }
                        item.Name = name.Text;
                        item.Description = description.Text;
                        item.StartPrice = int.Parse(startPrice.Text);
                        item.SellerId = int.Parse(sellerId.Text);
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
                    if (!string.IsNullOrEmpty(endPrice.Text) && !string.IsNullOrEmpty(buyerId.Text))
                    {
                        item.EndPrice = int.Parse(endPrice.Text);
                        item.BuyerId = int.Parse(buyerId.Text);
                    }
                    item.Name = name.Text;
                    item.Description = description.Text;
                    item.StartPrice = int.Parse(startPrice.Text);
                    item.SellerId = int.Parse(sellerId.Text);
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