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

namespace AuctionInterface.DataPages.AuctionPages
{
    /// <summary>
    /// Логика взаимодействия для AuctionEditAdd.xaml
    /// </summary>
    public partial class AuctionEditAdd : Page
    {
        Window _window;
        int _id;
        List<string> data = new List<string>();
        public AuctionEditAdd(Window window)
        {
            InitializeComponent();
            
            _window =window;
        }

        public AuctionEditAdd(string name,string adress,DateTimeOffset auctionDate,string specify,int id,Window window)
        {
            InitializeComponent();
            create.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Visible;
            this.name.Text = name;
            this.adress.Text = adress;
            this.date.Text = auctionDate.DateTime.ToShortDateString();
            this.specify.Text = specify;
            _id = id;
            _window = window;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            
            if (!IsDataNull())
            {
                using (var context = new AuctionContext())
                {
                    context.Auctions.Add(new Auction() { Name = name.Text, Adress = adress.Text,AuctionDate=DateTimeOffset.Parse(date.Text),Specify=specify.Text });
                    context.SaveChanges();
                }
                MessageBox.Show("Added");
                _window.Content = new AuctionPage(_window);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private bool IsDataNull()
        {
            data.AddRange(new List<string> { name.Text, adress.Text,date.Text,specify.Text });
            foreach(var str in data)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
