using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using FoodFinder.Models;
using System.Web.Mvc;
using FoodFinder.Tests;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using FoodFinder.Tests.Repositories;

namespace FoodFinder.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        // test passed 10/12/18 - 14:35 Get the products when typing the product name in the FoodFinder bar
        [TestMethod]
        public async Task Get()
        {
            IProductRepository pr = new ProductRepository();
            IPriceWatchRepository pwr = new TestPriceWatchRepository();

            var controller = new ProductController(pr, pwr, new CurrentUser("TestUser", true));

            var res = (ViewResult)await controller.Get("chocolate", 0);

            Assert.IsNotNull(res.Model);
            Assert.AreEqual("ProductView", res.ViewName);
        }
      // test passed 10/12/18 - 14:35 Get the product in already in the price watch 

        [TestMethod]
        public async Task GetWithPriceWatches()
        {
            IProductRepository pr = new ProductRepository();
            IPriceWatchRepository pwr = new TestPriceWatchRepository();

            var chocolates = await pr.GetProductsAsync("chocolate", 0);

            int idCount = 0;
            string userId = "Test-123";

            foreach (var c in chocolates)
            {
                pwr.Create(new PriceWatch()
                {
                    CreationDate = DateTime.Now,
                    Enabled = true,
                    Id = idCount++,
                    ImageUrl = c.ImageUrl,
                    ProductDescription = c.Description,
                    ProductId = c.Id,
                    ProductName = c.Name,
                    UserId = userId
                });
            }
            var controller = new ProductController(pr, pwr, new CurrentUser(userId, true));

            var res = (ViewResult)await controller.Get("chocolate", 0);
            var products = (IEnumerable < ProductViewModel >) res.Model;

            Assert.IsTrue(products.All(d => d.HasPriceWatch));

        }


    }
}