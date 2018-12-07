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

        [TestMethod()]
        public void IndexTest()
        {           
            Assert.Fail();
        }

        // test passed 06/12/2018 - arround 18: 00 testing just the view
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



        //trying again a different one now: 
        //[TestMethod()]
        //public async Task CreateInvalidPriceWatchEntry()
        //{

        //    var priceWatchEntry = new PriceWatchEntry();

        //    _service.Expect(s => Create(priceWatchEntry)).Returns(false);
        //    var controller = new PriceWatchEntryController(_service.Object);

        //    var result = (ViewResult)controller.Create(priceWatchEntry);

        //    Assert.AreEqual("Create", result.ViewName);
        //}

        //[TestMethod()]
        //public async Task Create()
        //{
        //    // 4th Try  did not pass but there was not  any errors----------------------------------------------------------------
        //    TestApplicationDbContext ff = new TestApplicationDbContext();
        //    PriceWatchEntry pwEntry = new PriceWatchEntry
        //    {
        //        Date = DateTime.Now,
        //        Id = 10,
        //        Price = 2,
        //        PriceIndicator = PriceIndicator.Same
        //    };
        //    var controller = new PriceWatchEntryController(ff);
        //    var result = await controller.Create() as System.Web.Http.Results.RedirectToRouteResult;
        //    Assert.AreEqual("Details", result.RouteValues["action"]);
        //}
               
            //1st try: did not work error on the Create
            //TestApplicationDbContext ff = new TestApplicationDbContext();
            //PriceWatch pw1 = new PriceWatch()
            //{
            //    UserId = "12222222222",
            //    ProductId = 293749766,
            //    CreationDate = DateTime.Now,
            //    Enabled = true,
            //    ProductName = "Terry's Chocolate Orange Milk Chocolate Box 157G",
            //    ProductDescription = "Milk chocolate flavoured with real orange",
            //    ImageUrl = "http://img.tesco.com/Groceries/pi/863/3664346304863/IDShot_90x90.jpg",
            //};

            //pw1.Entries = new List<PriceWatchEntry>();
            //pw1.Entries.Add(new PriceWatchEntry() { Date = pw1.CreationDate, Price = 3, PriceIndicator = PriceIndicator.Same });

            //2nd try: no errors but did not pass:---------------------------------------------------------------------------------------- 
            //Arrange
            //PriceWatchEntryController controller = new PriceWatchEntryController(new ApplicationDbContext());
            //PriceWatchEntry pwEntry = new PriceWatchEntry
            //{
            //    Date = DateTime.Now,
            //    Id = 10,
            //    Price = 2,
            //    PriceIndicator = PriceIndicator.Same
            //};

            ////Act
            //var result = controller.Create(pwEntry) as System.Web.Mvc.RedirectToRouteResult;

            ////Result
            //Assert.AreEqual("Create", result.RouteValues["action"]);

            // 3rd Try  not finished----------------------------------------------------------------
            //TestApplicationDbContext C = new TestApplicationDbContext();
            //PriceWatchEntryController controller = new PriceWatchEntryController(C);
            //var  pwEntry = new PriceWatchEntry
            //{
            //    Date = DateTime.Now,
            //    Id = 10,
            //    Price = 2,
            //    PriceIndicator = PriceIndicator.Same
            //};  

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}