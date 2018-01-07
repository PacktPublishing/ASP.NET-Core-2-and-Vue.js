using ECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }

        public static void EnsureSeeded(this EcommerceContext context)
        {
            if (UserManager.FindByEmailAsync("stu@ratcliffe.io").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Stu",
                    LastName = "Ratcliffe",
                    UserName = "stu@ratcliffe.io",
                    Email = "stu@ratcliffe.io",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
            }
        }
    }
}