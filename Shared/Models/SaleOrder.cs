using System;
using System.Collections.Generic;

namespace SharedAll.Models
{
    public class SaleOrder
    {
   
        public int SaleOrderID { get; set; }
        public int? ShopId { get; set; }
        public Shop Shop { get; set; }
        public DateTime DataTime { get; set; }
    //    public SaleOrderDetail SaleOrderDetail { get; set; }
        public bool Deleted { get; set; }
        public int UserActionId { get; set; }

        public ICollection<SaleOrderDetail> SaleOrderDetails { get; set; }
    }
}
