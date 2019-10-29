using AuctionInterface.CustomModels;
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
    /// Логика взаимодействия для LotPage.xaml
    /// </summary>
    public partial class LotPage : Page
    {
        Window _window;
        public LotPage(Window window)
        {
            InitializeComponent();
            _window = window;
            List<CustomLot> lots = new List<CustomLot>();
            using (var context = new AuctionContext())
            {
                for (int i = 0; i < context.Lots.Count(); i++)
                {
                    CustomLot lot = new CustomLot();
                    lot.Id = context.Lots.ToList()[i].Id;
                    lot.ItemId = context.Lots.ToList()[i].ItemId;
                    lot.Item = context.Items.ToList().FirstOrDefault(s => s.Id == context.Lots.ToList()[i].ItemId).Name;
                    lot.LotNumber = context.Lots.ToList()[i].LotNumber;
                    lots.Add(lot);
                }
            }

            table.ItemsSource = lots;
        }

        void ShowAddPage(object sender, RoutedEventArgs e)
        {
            _window.Content = new LotEditAddPage(_window);
        }

        void ShowEditPage(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem != null)
            {
                CustomLot lot = (CustomLot)table.SelectedItem;
                _window.Content = new LotEditAddPage(lot.ItemId, lot.LotNumber, lot.Id, _window);
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
                CustomLot lot = (CustomLot)table.SelectedItem;
                using (var context = new AuctionContext())
                {
                    context.Lots.Remove(context.Lots.SingleOrDefault(p => p.Id == lot.Id));
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
