using ApsoDemo.DataTables;
using ApsoDemo.Models;
using ApsoDemo.ViewModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ApsoDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class MainWindow : Window
    {
        public PersonDataTable personTable { get; set; }
        public string labelText { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);

            //personTable = new PersonDataTable();
            //Loaded += new RoutedEventHandler((o, e) =>
            //{
            //    labelText = "Iniciado";
            //    //personTable.getList();
            //});
        }
    }
}
