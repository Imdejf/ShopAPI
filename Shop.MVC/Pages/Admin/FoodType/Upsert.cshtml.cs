using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.Utility;

namespace Shop.MVC.Pages.Admin.FoodType
{
    [Authorize(Roles = SD.ManagerRole)]

    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.FoodType FoodTypeObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            FoodTypeObj = new Models.FoodType();
            if (id != null)
            {
                FoodTypeObj = _unitOfWork.FoodType.GetFirstOrDefualt(u => u.Id == id);
                if (FoodTypeObj == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FoodTypeObj.Id == 0)
            {
                _unitOfWork.FoodType.Add(FoodTypeObj);
            }
            else
            {
                _unitOfWork.FoodType.Update(FoodTypeObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

