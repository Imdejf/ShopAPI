using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.Models;
using Shop.Models.ViewModels;

namespace Shop.MVC.Pages.Admin.Order
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public OrderDetailsVM orderDetailsVM { get; set; }
        public void OnGet(int id)
        {
            orderDetailsVM = new OrderDetailsVM()
            {
            OrderHeader = _unitOfWork.OrderHeader.GetFirstOrDefualt(m => m.Id == id),
            OrderDetails = _unitOfWork.OrderDetails.GetAll(m => m.OrderId == id).ToList()
            };
            orderDetailsVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefualt(u => u.Id == orderDetailsVM.OrderHeader.UserId);
        }
    }
}
