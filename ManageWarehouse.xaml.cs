using MahApps.Metro.Controls;
using OREX.Model;
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
    /// Interaction logic for ManageWarehouse.xaml
    /// </summary>
    public partial class ManageWarehouse : MetroWindow
    {
        List<OrexClass.WarehouseList> lWarehouse = new List<OrexClass.WarehouseList>();
        public ManageWarehouse()
        {
            InitializeComponent();
        }

        private void GetWarehouses()
        {
            try
            {
                using (var db = new OrexEntities())
                {

                    var warehouses = db.Warehouses.ToList();

                    lWarehouse = new List<OrexClass.WarehouseList>();

                    foreach (var x in warehouses)
                    {
                        Model.OrexClass.WarehouseList warehouse = new Model.OrexClass.WarehouseList();
                        warehouse.WarehouseID = x.WarehouseID;
                        warehouse.WarehouseCode = x.WarehouseCode.ToUpper();
                        warehouse.ContactNo = x.Phone1 + x.Phone2 + x.Phone3 + x.Phone4;
                        warehouse.ContactPerson = x.LastName.ToUpper() + ", " + x.FirstName.ToUpper();
                        warehouse.Email = x.Email;
                        lWarehouse.Add(warehouse);

                    }

                    datagridview.ItemsSource = lWarehouse.OrderBy(m => m.ContactPerson).ToList();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong", "System Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetWarehouses();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddWarehouse addWarehouse = new AddWarehouse();
            addWarehouse.mode = 1;
            addWarehouse.ShowDialog();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetWarehouses();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchkey = tbSearch.Text.ToUpper();
            datagridview.ItemsSource = lWarehouse.Where(m=>m.WarehouseCode.Contains(searchkey)).OrderBy(m => m.ContactPerson).ToList();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var x = ((OrexClass.WarehouseList)datagridview.SelectedItem);
            AddWarehouse addWarehouse = new AddWarehouse();
            addWarehouse.warehouseid = x.WarehouseID;
            addWarehouse.mode = 2;
            addWarehouse.Show();
        }
    }
}
