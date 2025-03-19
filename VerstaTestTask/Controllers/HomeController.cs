using Microsoft.AspNetCore.Mvc;
using VerstaTestTask.Domain;
using VerstaTestTask.Service;
using VerstaTestTask.Web.Models;

namespace VerstaTestTask.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOrderService orderService, ILogger<HomeController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<OrderViewModel> model = new();
            try
            {
                List<Order> orders = _orderService.GetAll();
                orders.ForEach(o =>
                {
                    model.Add(new OrderViewModel() 
                    {
                        Id = o.Id, 
                        Number = o.Number, 
                        PickUpDate = o.PickUpDate, 
                        RecieverAdress = o.RecieverAdress,
                        RecieverCity = o.RecieverCity,
                        SenderAdress = o.SenderAdress,
                        SenderCity = o.SenderCity,
                        WeightInGrams = o.WeightInGrams
                    });
                });
            }
            catch (Exception ex) 
            {
                _logger.LogError("Could not get orders from database: " + ex.Message);
            }
            return View(model);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _orderService.AddAsync(new Order
                    {
                        PickUpDate = model.PickUpDate,
                        RecieverAdress = model.RecieverAdress,
                        RecieverCity = model.RecieverCity,
                        SenderAdress = model.SenderAdress,
                        SenderCity = model.SenderCity,
                        WeightInGrams = model.WeightInGrams
                    });

                    model.IsNew = true;
                    return RedirectToAction("Home", "OrderInfo", model);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Could not create order: " + ex.Message);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> OrderInfo(Guid id)
        {
            OrderViewModel? model;
            try
            {
                var order = await _orderService.GetByIdAsync(id);
                model = new OrderViewModel()
                {
                    Id = order.Id,
                    Number = order.Number,
                    PickUpDate = order.PickUpDate,
                    RecieverAdress = order.RecieverAdress,
                    RecieverCity = order.RecieverCity,
                    SenderAdress = order.SenderAdress,
                    SenderCity = order.SenderCity,
                    WeightInGrams = order.WeightInGrams
                };
            }
            catch (Exception ex)
            {
                model = null;
                _logger.LogError("Could not get order " + id + " from database: " + ex.Message);
            }
            return View(model);
        }
        public IActionResult OrderInfo(OrderViewModel model)
        {
            return View(model);
        }
    }
}
