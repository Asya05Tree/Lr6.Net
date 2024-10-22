using Microsoft.AspNetCore.Mvc;
using Lr6.Models;

namespace Lr6.Controllers
{
    public class PizzaOrderController : Controller
    {
        private readonly List<ProductModel> _pizzas;

        public PizzaOrderController(List<ProductModel> pizzas)
        {
            _pizzas = pizzas;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (DateTime.Now.Year - user.BirthYear >= 16 || DateTime.Now.Year - user.BirthYear <= 80)
                {
                    return RedirectToAction("Order");
                }
                else
                {
                    ModelState.AddModelError("", "Вам має бути не менше 16 років і не більше 80");
                }
            }
            return View(user);
        }

        public IActionResult Order()
        {
            ViewBag.Pizzas = _pizzas;
            return View(new OrderViewModel());
        }

        [HttpPost]
        public IActionResult Order(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderViewModel = new OrderViewModel
                {
                    PizzaCount = model.PizzaCount,
                    OrderItems = new List<OrderItemViewModel>()
                };

                for (int i = 0; i < model.PizzaCount; i++)
                {
                    orderViewModel.OrderItems.Add(new OrderItemViewModel
                    {
                        OrderItemId = i + 1
                    });
                }

                ViewBag.Pizzas = _pizzas;
                return View("SelectPizzas", orderViewModel);
            }
            ViewBag.Pizzas = _pizzas;
            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmOrder(OrderViewModel model)
        {
            foreach (var item in model.OrderItems)
            {
                item.SelectedPizza = _pizzas.FirstOrDefault(p => p.Id == item.SelectedPizzaId);
            }
            return View("OrderConfirmation", model);
        }

        [HttpPost]
        public JsonResult UpdatePizza(int orderItemId, int pizzaId)
        {
            var pizza = _pizzas.FirstOrDefault(p => p.Id == pizzaId);
            return Json(new { success = true, pizza = pizza });
        }
    }
}