using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Report
{
    public class Contact
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String Email { get; set; }
        public String Subject { get; set; }
        public String Cellphone { get; set; }
        public String Message { get; set; }
        public String CreatedDate { get; set; }
        public Int32 Status { get; set; }
        public string IsCheckbox { get; set; }
        public string Index { get; set; }
       
    }
}
