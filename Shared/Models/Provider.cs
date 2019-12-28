using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedAll.Models
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }
        public string NameProvider { get; set; }
        public decimal Phone { get; set; }
        public string Address { get; set; }
        public bool Deleted { get; set; }
        public int? UserActionId { get; set; }

        public ICollection<DocEnterProduct> DocEnterProducts { get; set; }
        
    }
}
