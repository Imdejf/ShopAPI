using Shop.DataAccess.Data.Repository.IRepository;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.DataAccess.Data.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ShopDbContext _db;
        public OrderHeaderRepository(ShopDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderHeader orderHeader)
        {
            var orderHeaderFromDb = _db.OrderHeader.FirstOrDefault(m => m.Id == orderHeader.Id);

            _db.OrderHeader.Update(orderHeaderFromDb);
            _db.SaveChanges();

        }
    }
}
