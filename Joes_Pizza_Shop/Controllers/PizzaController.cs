using Joes_Pizza_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Generic;

namespace Joes_Pizza_Shop.Controllers
{
    public class PizzaController : Controller
    {
        static List<Models.Pizza> pizzaList = new List<Models.Pizza>()
        {
            new Models.Pizza(){ Pizza_Id=1, Pizza_Name="Margherita", Pizza_Size="Large", Pizza_Price=360.25, Pizza_Discount=5,pizza_Quantity=3},
            new Models.Pizza(){ Pizza_Id=2, Pizza_Name="Sicilian", Pizza_Size="Small", Pizza_Price=149.25, Pizza_Discount=5,pizza_Quantity=3},
            new Models.Pizza(){ Pizza_Id=3, Pizza_Name="Greek pizza", Pizza_Size="Medium", Pizza_Price=254.25, Pizza_Discount=5,pizza_Quantity=2},
            new Models.Pizza(){ Pizza_Id=4, Pizza_Name="Pepperoni", Pizza_Size="Large", Pizza_Price=450.25, Pizza_Discount=5,pizza_Quantity=5}
        };
        public List<Models.Pizza> DisplayAll()
        {
            return pizzaList;
        }
        public  List<Models.Pizza>pizzaByid(int id)
        {
            List<Models.Pizza> emp = pizzaList.FindAll(e => e.Pizza_Id == id);
            return emp;
        }
        static List<OrderInfo> orderList = new List<OrderInfo>();
        public IActionResult Index()
        {
            ViewBag.pizza = pizzaList.Count();
            return View(pizzaList);
        }
        public IActionResult Checkout()
        {
            return View(orderList);
        }
        public IActionResult Cart(int id)
        {
            var pizza = pizzaList.Find(e => e.Pizza_Id == id);
            TempData["id"] = id;
            return View(pizza);
        }
        [HttpPost]
        public IActionResult Cart(IFormCollection f)
        {
            OrderInfo order=new OrderInfo();
            int id1 = Convert.ToInt32(TempData["id"]);
            var pizza = pizzaList.Find(e => e.Pizza_Id == id1);
            order.Order_Id = new Random().Next(100,499);
            order.Pizza_Id = id1;
            order.Pizza_Name = pizza.Pizza_Name;
            order.Pizza_Size=pizza.Pizza_Size;
            order.Pizza_Price = pizza.Pizza_Price;
            order.Pizza_Discount = pizza.Pizza_Discount;
            order.pizza_Quantity = pizza.pizza_Quantity;
            order.Order_Price =( (order.pizza_Quantity) * (order.Pizza_Price))-5;
            orderList.Add(order);
            return RedirectToAction("Checkout");
        }
        public IActionResult Welcome()
        {
            return View();
        }
        
    }
}
