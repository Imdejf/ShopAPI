using Shop.DataAccess.Data.Repository.IRepository;
using Shop.Models;
namespace Shop.DataAccess.Data.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart> , IShoppingCartRepository
    {
        private readonly ShopDbContext _db;

        public ShoppingCartRepository(ShopDbContext db) : base(db)
        {
            _db = db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }
    }
}
