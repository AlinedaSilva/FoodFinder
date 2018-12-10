using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFinder.Models;
using System.Web.Mvc;
using FoodFinder.Tests;
using System.Web.Http.Results;
using FoodFinder.Controllers;
using Moq;

namespace FoodFinder.Controllers.Tests
{
    [TestClass()]
    public class PriceWatchEntryControllerTests
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext applicationDbContext;

        public PriceWatchEntryControllerTests(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public PriceWatchEntryControllerTests()
        {
        }

        // test passed 06/12/2018 - arround 18:00 testing just the view
        [TestMethod()]
        public void TestDetailsView()
        {
            var controller = new PriceWatchEntryController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        // test passed 07/12/2018 - 10:58 testing just the view
        [TestMethod()]
        public void TestCreateView()
        {
            var controller = new PriceWatchEntryController();
            var result = controller.Create(3) as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }
    }
}