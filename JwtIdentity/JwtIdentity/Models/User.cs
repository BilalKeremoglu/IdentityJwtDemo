using Microsoft.AspNetCore.Identity;

namespace JwtIdentity.Models
{
    public class User: IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isActive { get; set; }
    }
}
