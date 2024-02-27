using Joes_Pizza_Shop.Controllers;
using Joes_Pizza_Shop.Models;
using Microsoft.AspNetCore.Mvc;
namespace NunitPizza
{
    [TestFixture]
    public class Tests
    {
        PizzaController controller;
        [SetUp]
        public void Setup()
        {
            controller= new PizzaController();
        }

        [Test]
        public void DisplayAllTest()
        {   
            foreach (var item in controller.DisplayAll())
            {
                Assert.IsNotNull(item);
            }
        }
        [Test]
        public void DisplayByIdTest2()
        {
            foreach (var item1 in controller.pizzaByid(2))
            {
                Assert.IsNotNull(item1);
            }
        }
        [Test]
        public void RedirectingTest() 
        {
            var controll = new PizzaController();
            
            
        }
    }
}