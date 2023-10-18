using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            ViewBag.Message = "this is supposed to be the admin dashboard";
            return View();
        }
    }
}
