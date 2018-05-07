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
    /// Interaction logic for ManageContacts.xaml
    /// </summary>
    public partial class ManageContacts : MetroWindow
    {
        List<OrexClass.ContactList> lContact = new List<OrexClass.ContactList>();
        public ManageContacts()
        {
            InitializeComponent();
        }

        private void GetContacts()
        {
            try
            {
                using (var db = new OrexEntities())
                {
                   
                    var contacts = db.Contacts.ToList();

                    lContact = new List<OrexClass.ContactList>();

                    foreach (var x in contacts)
                    {
                        Model.OrexClass.ContactList contact = new Model.OrexClass.ContactList();
                        contact.ContactID = x.ContactID;
                        contact.Company = x.Company;
                        contact.ContactNo = x.Phone1 + x.Phone2 + x.Phone3 + x.Phone4;
                        contact.ContactPerson = x.LastName.ToUpper() + ", " + x.FirstName.ToUpper();
                        contact.Email = x.Email;
                        
                        if (x.Category == 1)
                        {
                            contact.Category = "Customer";
                        }
                        else if (x.Category == 2)
                        {
                            contact.Category = "Supplier";
                        }
                        else if (x.Category == 3)
                        {
                            contact.Category = "Misc";
                        }

                        lContact.Add(contact); 

                    }

                    datagridview.ItemsSource = lContact.OrderBy(m => m.ContactPerson).ToList();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong", "System Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetContacts();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var x = ((OrexClass.ContactList)datagridview.SelectedItem);
            AddContact addContact = new AddContact();
            addContact.contactid = x.ContactID;
            addContact.mode = 2;
            addContact.Show();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact();
            addContact.mode = 1;
            addContact.ShowDialog();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetContacts();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchkey = tbSearch.Text.ToUpper();
            datagridview.ItemsSource = lContact.Where(m=>m.ContactPerson.Contains(searchkey)).OrderBy(m => m.ContactPerson).ToList();
        }
    }
}
