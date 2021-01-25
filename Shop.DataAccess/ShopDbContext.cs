using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shop.DataAccess
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
