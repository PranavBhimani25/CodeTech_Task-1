using CodeTech_Task_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeTech_Task_1.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly AppDbContext _context;

        public UserController(ILogger<UserController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult UserHomePage()
        {
            return View();
        }

        public IActionResult Profile()
        {
            var profile = _context.Customers.ToList();
            return View(profile);
        }

        public async Task<IActionResult> Shop()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

    }
}
