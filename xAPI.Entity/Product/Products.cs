using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Library.Base;

namespace xAPI.Entity.Product
{
    public class Products : BaseEntity
    {
        public String SKU { get; set; }
        public String FileName { get; set; }
        public Int32 CategoryId { get; set; }
        public String FileExtension { get; set; }
        public String FilePublicName { get; set; }
        public Decimal UnitPrice { get; set; }
        public Int32 Stock { get; set; }
        public Decimal PriceOffer { get; set; }
        public String UniMed { get; set; }
        public String NameResource { get; set; }
        public String DocType { get; set; }
        public Int16 IsUpload { get; set; }
    }
}
