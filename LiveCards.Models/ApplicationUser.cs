using Microsoft.AspNetCore.Identity; 

namespace LiveCards.Models
{
 
    public partial class ApplicationUser : IdentityUser
    { 
        public string ProfileImage { get; set; }
    }
}
