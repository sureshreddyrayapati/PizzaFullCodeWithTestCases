using Microsoft.VisualStudio.TestTools.UnitTesting;
using Joes_Pizza_Shop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joes_Pizza_Shop.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Joes_Pizza_Shop.Controllers.Tests
{
    [TestClass()]

    public class PizzaControllerTests
    {
        PizzaController controller;
        
        [TestMethod()]
        public void Setup()
        {
            controller = new PizzaController();
            
        }
        public void DisplayAllTest()
        {
            foreach (var s in controller.pizzaByid(2))
            {
                Assert.IsNotNull(s.Pizza_Id);
            }
        }
        [TestMethod]
        public void IndexTest()
        {
            PizzaController pizzaController = new PizzaController();
            ViewResult result = pizzaController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}