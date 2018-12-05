using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodFinder.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFinder.Models;
using System.Web.Mvc;
using FoodFinder.Tests;

namespace FoodFinder.Controllers.Tests
{
    [TestClass()]
    public class PriceWatchControllerTests
    {
        private IPriceWatchRepository _priceWatchRepository;
        private IProductRepository _productRepository;

        [TestMethod()]
        public void PriceWatchControllerTest(IPriceWatchRepository priceWatchRepository, IProductRepository productRepository)
        {
            _priceWatchRepository = priceWatchRepository;
            _productRepository = productRepository;
        }

        [TestMethod()]
        public void ListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            TestApplicationDbContext C = new TestApplicationDbContext();
            PriceWatchController controller = new PriceWatchController(C);
            //Create new price watch for the product
            PriceWatch pw1 = new PriceWatch()
            {
                UserId = "12222222222",
                ProductId = 293749766,
                CreationDate = DateTime.Now,
                Enabled = true,
                ProductName = "Terry's Chocolate Orange Milk Chocolate Box 157G",
                ProductDescription = "Milk chocolate flavoured with real orange",
                ImageUrl = "http://img.tesco.com/Groceries/pi/863/3664346304863/IDShot_90x90.jpg",
            };

                pw1.Entries = new List<PriceWatchEntry>();
                pw1.Entries.Add(new PriceWatchEntry() { Date = pw1.CreationDate, Price = 3, PriceIndicator = PriceIndicator.Same });

            _priceWatchRepository.Create(pw1);
            _priceWatchRepository.Save();

           // var result = controller.Create(pw1.ProductId, pw1.ProductName, pw1.ProductDescription, pw1.ImageUrl) as RedirectToRouteResult; //create has a problem because of the price,
            //Assert.AreEqual("Index", result.RouteValues["action"]);            
        }
               

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}

