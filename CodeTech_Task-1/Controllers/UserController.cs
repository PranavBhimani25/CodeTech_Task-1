using Microsoft.AspNetCore.Mvc;

namespace CodeTech_Task_1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserHomePage()
        {
            return View();
        }
    }
}
