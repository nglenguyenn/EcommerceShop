using Microsoft.AspNetCore.Authorization;

namespace EcommerceShop.BackEnd.Security.Authorization.AdminRoleHandler
{
    public class AdminRoleRequirement : IAuthorizationRequirement
    {
        public AdminRoleRequirement() { }
    }
}