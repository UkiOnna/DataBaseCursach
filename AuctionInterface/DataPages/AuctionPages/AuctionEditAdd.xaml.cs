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
        public AuctionEditAdd(Window window)
        {
            InitializeComponent();
        }

        public AuctionEditAdd(string name,string Adress,DateTimeOffset auctionDate,string specify,int id,Window window)
        {

        }
    }
}
