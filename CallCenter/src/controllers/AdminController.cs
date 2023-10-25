using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            ViewBag.Message = "this is supposed to be the admin dashboard to view employees and logs";
            return View();
        }
    }
}
