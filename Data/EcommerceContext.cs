using ECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class EcommerceContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
        { }
    }
}