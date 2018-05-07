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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : MetroWindow
    {
        public int mode;
        public int empid;
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void GetEmployeeDetails()
        {
            try
            {
                using (var db = new OrexEntities())
                {
                    var employee = db.Employees.Where(m => m.EmployeeID == empid).FirstOrDefault();
                    tbCity.Text = employee.City; 
                    tbCountry.Text = employee.Country;                 
                    tbEmail.Text = employee.Email;
                    tbFirstName.Text = employee.FirstName;
                    tbJobTitle.Text = employee.JobTitle;
                    tbLastName.Text = employee.LastName;
                    tbNotes.Text = employee.Notes;
                    tbPCode.Text = employee.PostalCode;
                    tbPhone1.Text = employee.Phone1;
                    tbPhone2.Text = employee.Phone2;
                    tbPhone3.Text = employee.Phone3;
                    tbPhone4.Text = employee.Phone4;
                    tbProvince.Text = employee.Province;
                    tbStreet.Text = employee.Street;
          
                }
            }
            catch (Exception)
            {

                throw;
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
                        Employee employee = new Employee();
                        employee.City = tbCity.Text;
                        employee.Country = tbCountry.Text;
                        employee.Email = tbEmail.Text;
                        employee.FirstName = tbFirstName.Text;
                        employee.JobTitle = tbJobTitle.Text;
                        employee.LastName = tbLastName.Text;
                        employee.Notes = tbNotes.Text;
                        employee.Phone1 = tbPhone1.Text;
                        employee.Phone2 = tbPhone2.Text;
                        employee.Phone3 = tbPhone3.Text;
                        employee.Phone4 = tbPhone4.Text;
                        employee.PostalCode = tbPCode.Text;
                        employee.Province = tbProvince.Text;
                        employee.Street = tbStreet.Text;

                        db.Employees.Add(employee);
                        db.SaveChanges();
                        MessageBox.Show("Add Success", "System Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (mode == 2)
                    {
                        var employee = db.Employees.Where(m => m.EmployeeID == empid).FirstOrDefault();
                        employee.City = tbCity.Text;
                        employee.Country = tbCountry.Text;
                        employee.Email = tbEmail.Text;
                        employee.FirstName = tbFirstName.Text;
                        employee.JobTitle = tbJobTitle.Text;
                        employee.LastName = tbLastName.Text;
                        employee.Notes = tbNotes.Text;
                        employee.Phone1 = tbPhone1.Text;
                        employee.Phone2 = tbPhone2.Text;
                        employee.Phone3 = tbPhone3.Text;
                        employee.Phone4 = tbPhone4.Text;
                        employee.PostalCode = tbPCode.Text;
                        employee.Province = tbProvince.Text;
                        employee.Street = tbStreet.Text;                      
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

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (mode == 2)
            {
                this.Title = "UPDATE EMPLYOYEE";
                GetEmployeeDetails();
            }
        }
    }
}
