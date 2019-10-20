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
namespace AuctionInterface.DataPages.Client
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        Window _window;
        int _id;
        public AddClientPage(Window window)
        {
            InitializeComponent();
            _window = window;
        }

        public AddClientPage(string name,string surname,int id,Window window)
        {
            InitializeComponent();
            create.Visibility = Visibility.Hidden;
            edit.Visibility = Visibility.Visible;
            this.name.Text = name;
            this.surname.Text = surname;
            _id = id;
            _window = window;
        }

        private void CreatePerson(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(surname.Text))
            {
                using (var context = new AuctionContext())
                {
                    context.Clients.Add(new Person() { Name = name.Text, Surname = surname.Text });
                    context.SaveChanges();   
                }
                MessageBox.Show("Added");
                _window.Content = new ClientPage(_window);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void EditPerson(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(surname.Text))
            {
                using (var context = new AuctionContext())
                {
                    Person person=context.Clients.SingleOrDefault(p=>p.Id==_id);
                    person.Surname = surname.Text;
                    person.Name = name.Text;
                    context.SaveChanges();
                }
                MessageBox.Show("Edited");
                _window.Content = new ClientPage(_window);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }



        private void BackToMainMenu(object sender, RoutedEventArgs e)
        {
            _window.Content = new MainMenu(_window);
        }
    }
}
