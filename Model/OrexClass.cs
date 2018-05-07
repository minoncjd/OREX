using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OREX.Model
{
    class OrexClass
    {
        public class ContactList
        {
            public int ContactID { get; set; }
            public string Company { get; set; }
            public string ContactPerson { get; set; }
            public string ContactNo { get; set; }
            public string Email { get; set; }
            public string Category { get; set; }
           
        }

        public class EmployeeList
        {
            public int EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string ContactNo { get; set; }
            public string Email { get; set; }
        }

        public class WarehouseList
        {
            public int WarehouseID { get; set; }
            public string WarehouseCode { get; set; }
            public string ContactPerson { get; set; }
            public string ContactNo { get; set; }
            public string Email { get; set; }
        }
    }
}
