using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.BackEnd.ViewModel.CustomAuthentication
{
    public class LoginAuthModelVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}