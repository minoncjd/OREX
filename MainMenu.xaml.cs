using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace OREX
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : MetroWindow
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            ManageContacts manageContact = new ManageContacts();
            manageContact.ShowDialog();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            ManageEmployee manageEmployee = new ManageEmployee();
            manageEmployee.ShowDialog();
        }

        private void btnWareHouse_Click(object sender, RoutedEventArgs e)
        {
            ManageWarehouse manageWarehouse = new ManageWarehouse();
            manageWarehouse.ShowDialog();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
