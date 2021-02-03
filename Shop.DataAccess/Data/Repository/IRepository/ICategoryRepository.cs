using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();
        void Update(Category category);
    }
}
