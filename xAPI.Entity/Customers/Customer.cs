using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Customers
{
    public class Customer
    {
        public Int32 CustomerId { get; set; }
        public String FirstName { get; set; }
        public String LastNamePaternal { get; set; }
        public String LastNameMaternal { get; set; }
        public Int32 DocumentType { get; set; }
        public String NumberDocument { get; set; }
        public String CellPhone { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Int32 Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 UpdatedBy { get; set; }
        private String _estadodesc;
        public String EstadoDes
        {
            get
            {
                if (Status == 1) _estadodesc = "Activo"; else _estadodesc = "Inactivo";
                return _estadodesc;
            }
        }
        private String fullName;
        public String FullName
        {
            get
            {
                fullName = FirstName + " " + LastNamePaternal + " " + LastNameMaternal;
                return fullName;
            }
        }
    }
}
