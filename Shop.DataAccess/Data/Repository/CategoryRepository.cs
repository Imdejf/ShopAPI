using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.DataAccess.Data.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
namespace Shop.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ShopDbContext _db;
        
        public CategoryRepository(ShopDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }); ;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);

            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;

            _db.SaveChanges();
        }
    }
}
