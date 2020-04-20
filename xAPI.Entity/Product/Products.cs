using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Entity.Brand;
using xAPI.Entity.Category;
using xAPI.Library.Base;

namespace xAPI.Entity.Product
{
    public class Products : BaseEntity
    {
        public String SKU { get; set; }
        public String FileName { get; set; }
        public String FileExtension { get; set; }
        public String FilePublicName { get; set; }
        public Decimal UnitPrice { get; set; }
        public Int32 Stock { get; set; }
        public Decimal PriceOffer { get; set; }
        public String UniMed { get; set; }
        public String NameResource { get; set; }
        public String DocType { get; set; }
        public Int16 IsUpload { get; set; }

        Categorys objCategory;
        public Categorys category
        {
            get
            {
                objCategory = objCategory ?? new Categorys();
                return objCategory;
            }
            set
            {
                objCategory = value;
            }
        }
        Brands objBrand;
        public Brands brand
        {
            get
            {
                objBrand = objBrand ?? new Brands();
                return objBrand;
            }
            set
            {
                objBrand = value;
            }
        }
    }
}
