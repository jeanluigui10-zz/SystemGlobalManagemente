using System;
using xAPI.Library;
using xAPI.Library.Base;

namespace xAPI.Entity
{
    [Serializable]
    public class Resource : BaseEntity
    {
        public String Filename { get; set; }
        public String DocumentType { get; set; }
        public Boolean IsProfilePhoto { get; set; }
        public Boolean IsProductPicture { get; set; }
        //public clsDistributor Distributor { get; set; }
        public BaseEntity Type {set;get; }
        public String FileExtension { get; set; }
        public String NameResource { get; set; }
    }
}
