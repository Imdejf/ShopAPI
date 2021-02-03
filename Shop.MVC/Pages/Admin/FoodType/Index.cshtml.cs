using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Utility;

namespace Shop.MVC.Pages.Admin.FoodType
{
    [Authorize(Roles = SD.ManagerRole)]

    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
