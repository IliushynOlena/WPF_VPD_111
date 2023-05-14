using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _06_Notebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel model = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = model;   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model.deleteSelectedContact();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            model.DeleteAllContact();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            model.DublicateSelectedContact();
        }
    }
    class ViewModel
    {
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        public IEnumerable<Contact> Contacts => contacts;
        public Contact SelectedContact { get; set; }
        public ViewModel()
        {
            contacts.Add(new Contact() { Name = "Vova", Age = 30, Surname = "Pupkin", Phone = "+3807575828", IsMale = true });
            contacts.Add(new Contact() { Name = "Marusia", Age = 25, Surname = "Shishik", Phone = "+380771244", IsMale = false });
            contacts.Add(new Contact() { Name = "Olga", Age = 33, Surname = "Shelesh", Phone = "+38067285792", IsMale = false });

        }
        public void deleteSelectedContact()
        {   
            if(SelectedContact != null)
                contacts.Remove(SelectedContact);   
        }
        public void DublicateSelectedContact()
        {
            if (SelectedContact != null)
                contacts.Add(SelectedContact.Clone());
        }
        public void DeleteAllContact()
        {
            if (contacts.Any())
                contacts.Clear();
        }
    }
}
