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

namespace AuctionInterface.DataPages.LotPages
{
    /// <summary>
    /// Логика взаимодействия для LotEditAddPage.xaml
    /// </summary>
    public partial class LotEditAddPage : Page
    {
        Window _window;
        int _id;
        public LotEditAddPage(Window window)
        {
            InitializeComponent();
            _window = window;
        }

        public LotEditAddPage(int itemId, int lotNumber, int id, Window window)
        {
            InitializeComponent();
            create.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Visible;
            _window = window;
            this.itemId.Text = itemId.ToString();
            this.lotNumber.Text = lotNumber.ToString();
            _id = id;
        }

        private void Create(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(lotNumber.Text) && !string.IsNullOrEmpty(itemId.Text))
            {
                using (var context = new AuctionContext())
                {
                    context.Lots.Add(new Lot() { ItemId = int.Parse(itemId.Text), LotNumber = int.Parse(lotNumber.Text) });
                    context.SaveChanges();
                }
                MessageBox.Show("Added");
                _window.Content = new LotPage(_window);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(lotNumber.Text) && !string.IsNullOrEmpty(itemId.Text))
            {
                using (var context = new AuctionContext())
                {
                    Lot lot = context.Lots.SingleOrDefault(p => p.Id == _id);
                    lot.LotNumber = int.Parse(lotNumber.Text);
                    lot.ItemId = int.Parse(itemId.Text);
                    context.SaveChanges();
                }
                MessageBox.Show("Edited");
                _window.Content = new LotPage(_window);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _window.Content = new LotPage(_window);
        }
    }
}
