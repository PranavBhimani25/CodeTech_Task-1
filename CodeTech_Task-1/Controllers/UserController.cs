using CodeTech_Task_1.Data;
using CodeTech_Task_1.Helpers;
using CodeTech_Task_1.Models;
using Microsoft.AspNetCore.Authorization;
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
            var sessionValue = HttpContext.Session.GetString("UserSession");
            if (sessionValue != "active")
            {
                return RedirectToAction("LoginPage", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var sessionValue = HttpContext.Session.GetString("UserSession");
            if (sessionValue != "active")
            {
                return RedirectToAction("LoginPage", "Home");
            }

            var custIdSession = HttpContext.Session.GetInt32("Cust_Id");
            var profile = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == custIdSession);
            if (profile == null) { return NotFound(); }
            return View(profile);
        }

        public async Task<IActionResult> Shop()
        {
            var sessionValue = HttpContext.Session.GetString("UserSession");
            if (sessionValue != "active")
            {
                return RedirectToAction("LoginPage", "Home");
            }
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Add to cart
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            string cartKey = "Cart";

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(cartKey) ?? new List<CartItem>();
            var item = cart.FirstOrDefault(x => x.ProductId == id);
            if (item != null)
            {
                item.Quantity += 1;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Id = id,
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObjectAsJson(cartKey, cart);
            return RedirectToAction("Shop");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, bool increase)
        {
            string cartKey = "Cart";
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(cartKey) ?? new List<CartItem>();

            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                if (increase)
                    item.Quantity += 1;
                else if (item.Quantity > 1)
                    item.Quantity -= 1;
            }

            HttpContext.Session.SetObjectAsJson(cartKey, cart);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveItem(int cartItemId)
        {
            string cartKey = "Cart";

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(cartKey);
            if (cart != null)
            {
                var itemToRemove = cart.FirstOrDefault(i => i.Id == cartItemId);
                if (itemToRemove != null)
                {
                    cart.Remove(itemToRemove);
                    HttpContext.Session.SetObjectAsJson(cartKey, cart);
                }
            }

            return RedirectToAction("Cart");
        }


        // View cart
        public IActionResult Cart()
        {
            var sessionValue = HttpContext.Session.GetString("UserSession");
            if (sessionValue != "active")
            {
                return RedirectToAction("LoginPage", "Home");
            }
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            var userId = HttpContext.Session.GetInt32("Cust_Id");
            string cartKey = "Cart";
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(cartKey);

            if (cart == null || !cart.Any())
                return RedirectToAction("Cart");

            // Lookup the Customer by userId
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == userId);
            if (customer == null)
            {
                return Unauthorized();
            }

            var order = new Order
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cart.Sum(i => i.Price * i.Quantity),
                Status = OrderStatus.Pending,
                OrderItems = cart.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            HttpContext.Session.Remove(cartKey); // Clear cart

            return RedirectToAction("OrderSuccess");
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }

        public IActionResult OrderHistory()
        {
            return View();
        }

    }
}
