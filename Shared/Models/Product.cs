﻿using System.Collections.Generic;

namespace SharedAll.Models
{
    public class Product 
    {
     //  [Key]
       public int ProductId { get; set;}
       public double Barcode { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public int CategoryId { get; set; }
        public bool Deleted { get; set; }
       public int? UserActionId { get; set; }

       public ICollection<ShopBalanceGood> ShopBalanceGood { get; set; }
       public ICollection<DocEnterProduct> DocEnterProducts { get; set; }
       public ICollection<SaleOrderDetail> SaleOrderDetails { get; set; }
       public ICollection<SalePriseDoc> SalePriseDocs { get; set; }
       public ICollection<ShopProduct> ShopProducts { get; set; }
    }
}
