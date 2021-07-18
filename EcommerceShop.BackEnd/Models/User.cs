using Microsoft.AspNetCore.Identity;

namespace EcommerceShop.BackEnd.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
        }
        public User(string userName) : base(userName)
        {
        }

        [PersonalData]
        public string FullName { get; set; }
    }
}