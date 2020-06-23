using System;
using xAPI.Library.Base;

namespace xAPI.Entity.Category
{
    public class Categorys : BaseEntity
    {
        public String FileName { get; set; }
        public String FileExtension { get; set; }
        public String FilePublicName { get; set; }
        public String NameResource { get; set; }
        public String DocType { get; set; }
        public Int16 IsUpload { get; set; }

    }
}
