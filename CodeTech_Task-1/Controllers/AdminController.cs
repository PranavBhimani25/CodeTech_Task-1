using CodeTech_Task_1.Data;
using CodeTech_Task_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeTech_Task_1.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        private readonly AppDbContext _context;

        public AdminController(ILogger<AdminController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult AdminIndex()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Product()
        {
            var allproduct = _context.Products.ToList();
            return View(allproduct);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            else
            {
                foreach (var state in ModelState)
                {
                    var key = state.Key;
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Validation Error in '{key}' : '{error.ErrorMessage}'");
                    }
                }
            }
            return PartialView("_AddProductModal", product); // Return modal with validation
        }

        public IActionResult Semo()
        {
            return View();
        }
    }
}
