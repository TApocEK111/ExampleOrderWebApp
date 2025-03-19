using Microsoft.AspNetCore.Mvc;

namespace VerstaTestTask.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Order> orders = _db.Orders.ToList();
            return View(orders);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                await _db.Orders.AddAsync(order);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        public IActionResult OrderInfo(Guid id)
        {
            Order order = _db.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
