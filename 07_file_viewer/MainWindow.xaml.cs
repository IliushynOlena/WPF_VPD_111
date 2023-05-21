using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Runtime.CompilerServices;
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
using Path = System.IO.Path;

namespace _07_file_viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult res = dialog.ShowDialog();    

            if(res == CommonFileDialogResult.Ok)
            {
                //MessageBox.Show(dialog.FileName);
                viewModel.LoadFiles(dialog.FileName);
            }   
           
        }
    }
    class ViewModel :INotifyPropertyChanged
    {
        private ObservableCollection<FileInfo> files = new ObservableCollection<FileInfo>();
        public IEnumerable<FileInfo> Files => files;
        private string directoryPath;
        public string DirectoryPath { get=> directoryPath; 
            set {
                directoryPath = value;
                OnPropertyChanged(); OnPropertyChanged(nameof(DirectoryName));
            } 
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
        public string DirectoryName => DirectoryPath;
        private FileInfo selectedfile;
        public FileInfo SelectedFile 
        { get=>selectedfile; 
            set { selectedfile = value;OnPropertyChanged(); } 
        }
        public ViewModel()
        {
            LoadFiles(@"C:\Users\helen\Desktop\Заняття");
        }
        public void LoadFiles(string dirPath)
        {
            this.DirectoryPath = dirPath;
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            var data =  directory.GetFiles();

            files.Clear();
            foreach (var item in data)
            {
                files.Add(item);
            }
        }
    }
}
