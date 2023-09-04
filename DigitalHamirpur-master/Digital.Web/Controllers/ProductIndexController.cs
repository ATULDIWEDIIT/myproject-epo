using Microsoft.AspNetCore.Mvc;

namespace Digital.Web.Controllers
{
    public class ProductIndexController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}
