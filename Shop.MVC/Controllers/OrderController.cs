using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.Models;
using Shop.Models.ViewModels;
using Shop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get(string status = null)
        {
            List<OrderDetailsVM> orderListVM = new List<OrderDetailsVM>();

            IEnumerable<OrderHeader> orderHeaderList;

            if(User.IsInRole(SD.CustomerRole))
            {
                //retrieve all orders for that customer
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                orderHeaderList = _unitOfWork.OrderHeader.GetAll(u => u.UserId == claim.Value, null, "ApplicationUser");
            }
            else
            {
                orderHeaderList = _unitOfWork.OrderHeader.GetAll(null, null, "ApplicationUser");
            }
            if(status=="cancelled")
            {
                orderHeaderList = orderHeaderList.Where(s => s.Status == SD.StatusCancelled || s.Status == SD.StatusRefunded);
            }
            else
            {
                if(status == "completed")
                {
                    orderHeaderList = orderHeaderList.Where(s => s.Status == SD.StatusCompleted);
                }
                else
                {
                    orderHeaderList = orderHeaderList.Where(s => s.Status == SD.StatusReady || s.Status == SD.StatusCancelled || s.Status == SD.StatusRefunded || s.Status == SD.PaymentStatusRejected);
                }
            }
            foreach(OrderHeader item in orderHeaderList)
            {
                OrderDetailsVM individual = new OrderDetailsVM
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetails.GetAll(o => o.OrderId == item.Id).ToList()
                };
            orderListVM.Add(individual);
            }
            return Json(new { data = orderListVM });
        }
    }
}
