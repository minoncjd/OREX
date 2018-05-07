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
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : MetroWindow
    {
        public int mode;
        public int contactid;

        public AddContact()
        {
            InitializeComponent();
        }

        private void GetContactDetails()
        {
            try
            {
                using (var db = new OrexEntities())
                {
                    var contact = db.Contacts.Where(m => m.ContactID == contactid).FirstOrDefault();
                    tbCity.Text = contact.City;
                    tbCompany.Text = contact.Company;
                    tbCountry.Text = contact.Country;
                    tbCredit.Text = contact.CreditLimit.ToString();
                    tbEmail.Text = contact.Email;
                    tbFirstName.Text = contact.FirstName;
                    tbJobTitle.Text = contact.JobTitle;
                    tbLastName.Text = contact.LastName;
                    tbNotes.Text = contact.Notes;
                    tbPCode.Text = contact.PostalCode;
                    tbPhone1.Text = contact.Phone1;
                    tbPhone2.Text = contact.Phone2;
                    tbPhone3.Text = contact.Phone3;
                    tbPhone4.Text = contact.Phone4;
                    tbProvince.Text = contact.Province;
                    tbStreet.Text = contact.Street;
                    tbTerms.Text = contact.PaymentTermDays.ToString();
                    tbTIN.Text = contact.TIN;
                    tbWebPage.Text = contact.WebPage;
                    cbSalesPerson.SelectedValue = contact.SalesPerson;

                    if (contact.Category == 1)
                    {
                        rbCustomer.IsChecked = true;
                    }
                    else if (contact.Category == 2)
                    {
                        rbSupplier.IsChecked = true;
                    }
                    else if (contact.Category == 3)
                    {
                        rbMisc.IsChecked = true;
                    }

                    if (contact.SalesInvoice == true)
                    {
                        chckboxSalesInvoice.IsChecked = true;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong", "System Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        Contact contact = new Contact();
                        if (rbCustomer.IsChecked == true)
                        {
                            contact.Category = 1;
                        }
                        else if (rbSupplier.IsChecked == true)
                        {
                            contact.Category = 2;
                        }
                        else if (rbMisc.IsChecked == true)
                        {
                            contact.Category = 3;
                        }

                        if (chckboxSalesInvoice.IsChecked == true)
                        {
                            contact.SalesInvoice = true;
                        }
                        else
                        {
                            contact.SalesInvoice = false;
                        }

                        contact.City = tbCity.Text;
                        contact.Company = tbCompany.Text;
                        contact.Country = tbCountry.Text;
                        contact.CreditLimit = Convert.ToInt32(tbCredit.Text);
                        contact.Email = tbEmail.Text;
                        contact.FirstName = tbFirstName.Text;
                        contact.JobTitle = tbJobTitle.Text;
                        contact.LastName = tbLastName.Text;
                        contact.Notes = tbNotes.Text;
                        contact.PaymentTermDays = Convert.ToInt32(tbTerms.Text);
                        contact.Phone1 = tbPhone1.Text;
                        contact.Phone2 = tbPhone2.Text;
                        contact.Phone3 = tbPhone3.Text;
                        contact.Phone4 = tbPhone4.Text;
                        contact.PostalCode = tbPCode.Text;
                        contact.Province = tbProvince.Text;
                        contact.SalesPerson = Convert.ToInt32(cbSalesPerson.SelectedValue);
                        contact.Street = tbStreet.Text;
                        contact.TIN = tbTIN.Text;
                        contact.WebPage = tbWebPage.Text;
                        contact.Street = tbStreet.Text;

                        db.Contacts.Add(contact);
                        db.SaveChanges();
                        MessageBox.Show("Add Success", "System Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else if (mode == 2)
                    {

                        var contact = db.Contacts.Where(m => m.ContactID == contactid).FirstOrDefault();
                        if (rbCustomer.IsChecked == true)
                        {
                            contact.Category = 1;
                        }
                        else if (rbSupplier.IsChecked == true)
                        {
                            contact.Category = 2;
                        }
                        else if (rbMisc.IsChecked == true)
                        {
                            contact.Category = 3;
                        }

                        if (chckboxSalesInvoice.IsChecked == true)
                        {
                            contact.SalesInvoice = true;
                        }
                        else
                        {
                            contact.SalesInvoice = false;
                        }

                        contact.City = tbCity.Text;
                        contact.Company = tbCompany.Text;
                        contact.Country = tbCountry.Text;
                        contact.CreditLimit = Convert.ToInt32(tbCredit.Text);
                        contact.Email = tbEmail.Text;
                        contact.FirstName = tbFirstName.Text;
                        contact.JobTitle = tbJobTitle.Text;
                        contact.LastName = tbLastName.Text;
                        contact.Notes = tbNotes.Text;
                        contact.PaymentTermDays = Convert.ToInt32(tbTerms.Text);
                        contact.Phone1 = tbPhone1.Text;
                        contact.Phone2 = tbPhone2.Text;
                        contact.Phone3 = tbPhone3.Text;
                        contact.Phone4 = tbPhone4.Text;
                        contact.PostalCode = tbPCode.Text;
                        contact.Province = tbProvince.Text;
                        contact.SalesPerson = Convert.ToInt32(cbSalesPerson.SelectedValue);
                        contact.Street = tbStreet.Text;
                        contact.TIN = tbTIN.Text;
                        contact.WebPage = tbWebPage.Text;

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
                this.Title = "UPDATE CONTACT";
                GetContactDetails();
            }
        }
 
    }
}
