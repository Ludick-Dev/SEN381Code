using Microsoft.AspNetCore.Mvc;

namespace CallCenter.src.controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            ViewBag.Message = "this is supposed to be the admin dashboard to view employees and logs. But in reality employees will be directed to their relevant page depending on what their job is";
            return View();
        }
    }
}
