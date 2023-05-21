using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace _06_Notebook
{
    class ViewModel
    {
        private RelayCommand dublicateCommand;
        private RelayCommand removeCommand;
        private RelayCommand clearCommand;

        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        public IEnumerable<Contact> Contacts => contacts;
        public ICommand DublicateCommand => dublicateCommand;
        public ICommand RemoveCommand => removeCommand;
        public ICommand ClearCommand => clearCommand;
        public Contact SelectedContact { get; set; }
        public ViewModel()
        {
            dublicateCommand = new RelayCommand((o)=> DublicateSelectedContact(), (o)=> SelectedContact != null);
            removeCommand = new RelayCommand((o)=> deleteSelectedContact(), (o) => SelectedContact != null);
            clearCommand = new RelayCommand((o)=> contacts.Clear(), (o)=> contacts.Any());

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
