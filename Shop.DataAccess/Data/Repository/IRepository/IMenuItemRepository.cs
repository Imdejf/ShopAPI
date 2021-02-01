using Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Data.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem menuItem);
    }
}
