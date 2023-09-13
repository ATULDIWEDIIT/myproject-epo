using Digital.Web.Code;
using Digital.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Digital.Web.Areas.Admin.Controllers
{   
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            if (CurrentUser.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View("~/Areas/Admin/Views/Dashboard/Index.cshtml");
        }
    }
}
