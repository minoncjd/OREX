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
    /// Interaction logic for AddWarehouse.xaml
    /// </summary>
    public partial class AddWarehouse : MetroWindow
    {
        public int mode;
        public int warehouseid;

        private void GetWarehouseDetails()
        {
            try
            {
                using (var db = new OrexEntities())
                {
                    var warehouse = db.Warehouses.Where(m => m.WarehouseID == warehouseid).FirstOrDefault();
                    tbCity.Text = warehouse.City;
                    tbCountry.Text = warehouse.Country;
                    tbEmail.Text = warehouse.Email;
                    tbFirstName.Text = warehouse.FirstName;
                    tbJobTitle.Text = warehouse.JobTitle;
                    tbLastName.Text = warehouse.LastName;
                    tbNotes.Text = warehouse.Notes;
                    tbPCode.Text = warehouse.PostalCode;
                    tbPhone1.Text = warehouse.Phone1;
                    tbPhone2.Text = warehouse.Phone2;
                    tbPhone3.Text = warehouse.Phone3;
                    tbPhone4.Text = warehouse.Phone4;
                    tbProvince.Text = warehouse.Province;
                    tbStreet.Text = warehouse.Street;
                    tbCode.Text = warehouse.WarehouseCode;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public AddWarehouse()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (mode == 2)
            {
                this.Title = "UPDATE WAREHOUSE";
                GetWarehouseDetails();

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new OrexEntities())
                {
                    if (mode == 1)
                    {
                        Warehouse warehouse = new Warehouse();

                        warehouse.City = tbCity.Text;
                        warehouse.Country = tbCountry.Text;
                        warehouse.Email = tbEmail.Text;
                        warehouse.FirstName = tbFirstName.Text;
                        warehouse.JobTitle = tbJobTitle.Text;
                        warehouse.LastName = tbLastName.Text;
                        warehouse.Notes = tbNotes.Text;
                        warehouse.Phone1 = tbPhone1.Text;
                        warehouse.Phone2 = tbPhone2.Text;
                        warehouse.Phone3 = tbPhone3.Text;
                        warehouse.Phone4 = tbPhone4.Text;
                        warehouse.PostalCode = tbPCode.Text;
                        warehouse.Province = tbProvince.Text;
                        warehouse.Street = tbStreet.Text;
                        warehouse.WarehouseCode = tbCode.Text;

                        db.Warehouses.Add(warehouse);
                        db.SaveChanges();
                        MessageBox.Show("Add Success", "System Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (mode == 2)
                    {
                        var warehouse = db.Warehouses.Where(m => m.WarehouseID == warehouseid).FirstOrDefault();

                        warehouse.City = tbCity.Text;
                        warehouse.Country = tbCountry.Text;
                        warehouse.Email = tbEmail.Text;
                        warehouse.FirstName = tbFirstName.Text;
                        warehouse.JobTitle = tbJobTitle.Text;
                        warehouse.LastName = tbLastName.Text;
                        warehouse.Notes = tbNotes.Text;
                        warehouse.Phone1 = tbPhone1.Text;
                        warehouse.Phone2 = tbPhone2.Text;
                        warehouse.Phone3 = tbPhone3.Text;
                        warehouse.Phone4 = tbPhone4.Text;
                        warehouse.PostalCode = tbPCode.Text;
                        warehouse.Province = tbProvince.Text;
                        warehouse.Street = tbStreet.Text;
                        warehouse.WarehouseCode = tbCode.Text;
                    
                        db.SaveChanges();
                        MessageBox.Show("Update Success", "System Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong", "System Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
