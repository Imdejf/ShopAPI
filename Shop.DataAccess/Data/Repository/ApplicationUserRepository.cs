using Shop.DataAccess.Data.Repository.IRepository;
using Shop.Models;
namespace Shop.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser> , IApplicationUserRepository
    {
        private readonly ShopDbContext _db;

        public ApplicationUserRepository(ShopDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
