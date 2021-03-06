﻿namespace SharedAll.Models
{
    public class ShopBalanceGood
    {
        public int ShopBalanceGoodId { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int DocEnterProductId { get; set; }
        public DocEnterProduct DocEnterProduct { get; set; }
        public int Amount { get; set; }
        public bool Deleted { get; set; }
        public int? UserActionId { get; set; }

    }
}
