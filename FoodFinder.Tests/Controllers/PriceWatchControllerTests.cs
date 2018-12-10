using FoodFinder.Controllers;
using FoodFinder.Models;
using FoodFinder.Tests;
using FoodFinder.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodFinder.Controllers.Tests
{
    [TestClass()]
    public class PriceWatchControllerTests
    {
        // test passed 10/12/18 testing the create action in the price watch. 
        [TestMethod]
        public async Task Create()
        {
            IProductRepository pr = new ProductRepository();
            IPriceWatchRepository pwr = new TestPriceWatchRepository();

            var currentUser = new CurrentUser("TEST-123", true);
            var pwController = new PriceWatchController(pr, pwr, currentUser);
            var productController = new ProductController(pr, pwr, currentUser);

            var c = (await pr.GetProductsAsync("chocolate", 0, 1)).FirstOrDefault();

            pwController.Create(c.Id, c.Price, c.Name, c.Description, c.ImageUrl, "chocolate", 0);

            var res = (ViewResult)await productController.Get("chocolate", 0);

            var product = ((IEnumerable<ProductViewModel>)res.Model).FirstOrDefault();

            Assert.IsTrue(product.HasPriceWatch);
        }
        //test passed 10/12 - arround 11:45 adding the product from the view to a list 
        [TestMethod]
        public async Task List()
        {
            IProductRepository pr = new ProductRepository();
            IPriceWatchRepository pwr = new TestPriceWatchRepository();

            var currentUser = new CurrentUser("Test-123", true);
            var pwController = new PriceWatchController(pr, pwr, currentUser);
            var productController = new ProductController(pr, pwr, currentUser);

            var chocolates = await pr.GetProductsAsync("chocolate", 0);

            int idCount = 0;
      

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
                    UserId = currentUser.Id,
                    Entries = new List<PriceWatchEntry>() { new PriceWatchEntry() { Date = DateTime.Now, Id = idCount, Price = c.Price, PriceIndicator = PriceIndicator.Same } }
                });

            }
            var res = (ViewResult)(await pwController.List());
            var priceWatches = (IEnumerable<PriceWatchViewModel>)res.Model;

            Assert.IsTrue(priceWatches.All(d => chocolates.Any(c=> c.Name == d.ProductName)) && priceWatches.Count() == chocolates.Count());
        }
    }
}






