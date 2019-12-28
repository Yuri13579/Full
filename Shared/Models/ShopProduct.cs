namespace SharedAll.Models
{
    public class ShopProduct
    {
        public int ShopProductId { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool Deleted { get; set; }
        public int? UserActionId { get; set; }


    }
}
