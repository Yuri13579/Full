using System;
using System.ComponentModel.DataAnnotations;

namespace SharedAll.Models
{
    public class SalePriseDoc
    {
        [Key]
        public int SalePriseDocId { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public decimal SalePrise { get; set; }
        public DateTime DateFrom { get; set; }
        public bool Deleted { get; set; }
        public int? UserActionId { get; set; }
    }
}
