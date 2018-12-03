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
            TestPriceWatchContext pr = new TestPriceWatchContext();
           
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}