using Microsoft.AspNetCore.Identity;

namespace Back.Models
{
    public class User: IdentityUser
    { 
        public int ProfileId { get; set; }

     //   public virtual Profile Profile { get; set; }
        
    }
}
