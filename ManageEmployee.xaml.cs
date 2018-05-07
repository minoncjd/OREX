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
    /// Interaction logic for ManageEmployee.xaml
    /// </summary>
    public partial class ManageEmployee : MetroWindow
    {
        List<OrexClass.EmployeeList> lEmployee = new List<OrexClass.EmployeeList>();
        public ManageEmployee()
        {
            InitializeComponent();
        }

        private void GetEmployees()
        {
           
            try
            {
                using (var db = new OrexEntities())
                {
                    lEmployee = new List<OrexClass.EmployeeList>();
                    var employees = db.Employees.ToList();

                    foreach (var x in employees)
                    {
                        OrexClass.EmployeeList employee = new OrexClass.EmployeeList();
                        employee.ContactNo = x.Phone1 + x.Phone2 + x.Phone3 + x.Phone4;
                        employee.EmployeeName = (x.LastName + ", " + x.FirstName).ToUpper();
                        employee.Email = x.Email;
                        lEmployee.Add(employee);
                    }

                    datagridview.ItemsSource = lEmployee.OrderBy(m => m.EmployeeName).ToList();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong", "System Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetEmployees();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var x = ((OrexClass.EmployeeList)datagridview.SelectedItem);
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.empid = x.EmployeeID;
            addEmployee.mode = 2;
            addEmployee.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.mode = 1;
            addEmployee.ShowDialog();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetEmployees();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchkey = tbSearch.Text.ToUpper();
            datagridview.ItemsSource = lEmployee.Where(m=>m.EmployeeName.Contains(searchkey)).OrderBy(m => m.EmployeeName).ToList();
        }
    }
}
