using System;
using xAPI.Library.Base;

namespace xAPI.Entity.Store
{
    public class Store : BaseEntity
    {
        public String Address { get; set; }
        public String Email { get; set; }
        public String Phone1 { get; set; }
        public String Phone2 { get; set; }
        public String AttentionHours { get; set; }
        public String NoteDelivery { get; set; }
        public String NoteSupport { get; set; }
        public String NotePromotions { get; set; }
        public String NotePayment { get; set; }
        public Int32 Year { get; set; }
        public String Banner { get; set; }
        public String Logo { get; set; }
        public String Facebook { get; set; }
        public String Instagram { get; set; }
        public String Youtube { get; set; }
        public String Twitter { get; set; }
    }
}
