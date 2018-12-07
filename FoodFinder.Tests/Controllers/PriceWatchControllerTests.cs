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
using System.Web.Http.Results;
using Moq;

namespace FoodFinder.Controllers.Tests
{
    [TestClass()]
    public class PriceWatchControllerTests
    {
        // testing the controller:
        private IMock<IPriceWatchRepository> _mockRepository;
        private ModelStateDictionary _modelState;
        private IFoodFinderContext _service;

        private IPriceWatchRepository _priceWatchRepository;
        private IProductRepository _productRepository;

        [TestMethod()]
        public void PriceWatchControllerTest(IPriceWatchRepository priceWatchRepository, IProductRepository productRepository)
        {
            _priceWatchRepository = priceWatchRepository;
            _productRepository = productRepository;
        }

        [TestMethod()]
        public void List()
        {
            Assert.Fail();
        }
       
        //[TestMethod()]
        //public async Task Create()
        //{
        // 1st Try ----------------------------------------------------------------
        //TestApplicationDbContext C = new TestApplicationDbContext();
        // PriceWatchController controller = new PriceWatchController(C);
        // //Create new price watch for the product
        // PriceWatch pw1 = new PriceWatch()
        // {
        //     UserId = "12222222222",
        //     ProductId = 293749766,
        //     CreationDate = DateTime.Now,
        //     Enabled = true,
        //     ProductName = "Terry's Chocolate Orange Milk Chocolate Box 157G",
        //     ProductDescription = "Milk chocolate flavoured with real orange",
        //     ImageUrl = "http://img.tesco.com/Groceries/pi/863/3664346304863/IDShot_90x90.jpg",
        // };

        // pw1.Entries = new List<PriceWatchEntry>();
        // pw1.Entries.Add(new PriceWatchEntry() { Date = pw1.CreationDate, Price = 3, PriceIndicator = PriceIndicator.Same });
        // var result = await controller.Create(pw1.ProductId, pw1.ProductName, pw1.ProductDescription) as System.Web.Mvc.RedirectToRouteResult;
        // Assert.AreEqual("Index", result.RouteValues["action"]);
        //----------------------------------------------------------------------------------
    }

    //[TestMethod()]
    //public void Remove()
    //{
    //    var context = new TestApplicationDbContext();
    //    var priceWatch = GetPriceWatch();
    //    context.PriceWatches.Add(priceWatch);

    //    var controller = new PriceWatchController(context);

    //    var result = controller.Remove(100) as OkNegotiatedContentResult<PriceWatch>;
    //    Assert.IsNotNull(result);
    //    Assert.AreEqual(priceWatch.Id, result.Content.Id);

    //    //Assert.Fail();
    //    }
        //PriceWatch GetPriceWatch()
        //{
        //    return new PriceWatch()
        //    {
        //        Id = 100,
        //        UserId = "12222222223",
        //        ProductId = 293749766,
        //        CreationDate = DateTime.Now,
        //        Enabled = true,
        //        ProductName = "Terry's Chocolate Orange Milk Chocolate Box 157G",
        //        ProductDescription = "Milk chocolate flavoured with real orange",
        //        ImageUrl = "http://img.tesco.com/Groceries/pi/863/3664346304863/IDShot_90x90.jpg",
        //    };
        //}
    }





