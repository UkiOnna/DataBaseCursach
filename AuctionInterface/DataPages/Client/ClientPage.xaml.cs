
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

namespace AuctionInterface.DataPages.Client
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        Window _window;
        public ClientPage(Window window)
        {
            InitializeComponent();
            _window = window;
            List<Person> people = new List<Person>();
            using (var context = new AuctionContext())
            {
                for (int i = 0; i < context.Clients.Count(); i++)
                {
                    people.Add(new Person() { Surname = context.Clients.ToList()[i].Surname, Name = context.Clients.ToList()[i].Name, Id = context.Clients.ToList()[i].Id });
                }
            }
            table.ItemsSource = people;
        }

        void ShowAddPage(object sender, RoutedEventArgs e)
        {
            _window.Content = new AddClientPage(_window);
        }

        void ShowEditPage(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem != null)
            {
                Person person = (Person)table.SelectedItem;
                _window.Content = new AddClientPage(person.Name, person.Surname, person.Id, _window);
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
                Person person = (Person)table.SelectedItem;
                using (var context = new AuctionContext())
                {
                    context.Clients.Remove(context.Clients.SingleOrDefault(p => p.Id == person.Id));
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
