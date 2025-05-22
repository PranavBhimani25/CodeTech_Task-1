using Microsoft.AspNetCore.Mvc;

namespace CodeTech_Task_1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
