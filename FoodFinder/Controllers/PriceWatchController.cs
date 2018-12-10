using FoodFinder.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodFinder.Controllers
{
    public class PriceWatchController : Controller
    {
        private IFoodFinderContext db = new FoodFinderContext();

        public PriceWatchController() { }

        private IPriceWatchRepository _priceWatchRepository;
        private IProductRepository _productRepository;
        private CurrentUser _currentUser;

        public PriceWatchController(IProductRepository productRepository, IPriceWatchRepository priceWatchRepository, CurrentUser currentUser)
        {
            _productRepository = productRepository;
            _priceWatchRepository = priceWatchRepository;
            _currentUser = currentUser;
        }

        //// GET: PriceWatch
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public async Task<ActionResult> List()
        {
            // If user isn't authenticated, he must login to see his price watch
            if (!_currentUser.IsAuthenticated)
            {
                // redirect
                return RedirectToAction("Login", "Account");
            }
            //get user's price watch
            var userPriceWatchList = _priceWatchRepository.GetPriceWatches(_currentUser.Id);

            // make view model
            var viewLst = new List<PriceWatchViewModel>();

            // indicator to save changes to database (if new entry is added)
            bool saveChanges = false;

            foreach (var pricewatch in userPriceWatchList)
            {
                // get last price added to that price watch
                var lastUpdate = pricewatch.Entries?.OrderByDescending(d => d.Date).FirstOrDefault();

                // if ther is a new date to search for
                if (lastUpdate.Date.Date < DateTime.Today)
                {
                    // get current product price from the api
                    var products = await _productRepository.GetProductsAsync(pricewatch.ProductName, 0, 1);
                    var productNow = products.FirstOrDefault();

                    //if product was found
                    if (productNow != null)
                    {
                        //indicate if the product price has gone up dow or stayed same

                        PriceIndicator indicator = PriceIndicator.Same;

                        if (productNow?.Price > lastUpdate?.Price)
                        {
                            indicator = PriceIndicator.Up;
                        }
                        if (productNow?.Price < lastUpdate?.Price)
                        {
                            indicator = PriceIndicator.Down;
                        }

                        var newEntry = new PriceWatchEntry()
                        {
                            Date = DateTime.Now,
                            Price = productNow.Price,
                            PriceIndicator = indicator
                        };
                        // must update the database at the end (cannot update now because we are in the middle of a query)
                        pricewatch.Entries.Add(newEntry);
                        lastUpdate = newEntry;
                        saveChanges = true;
                    }
                }
                //create view model for that price watch
                var viewModel = new PriceWatchViewModel()
                {
                    Id = pricewatch.Id,
                    CreationDate = pricewatch.CreationDate,
                    LastPrice = lastUpdate?.Price,
                    ImageUrl = pricewatch?.ImageUrl,
                    LastUpdate = lastUpdate?.Date,
                    PriceIndicatorGlyphicon = PriceWatchEntryViewModel.GetPriceIndicatorGlyphicon(lastUpdate?.PriceIndicator),
                    PriceIndicatorBgColor = PriceWatchEntryViewModel.GetPriceIndicatorBgColor(lastUpdate?.PriceIndicator),
                    ProductDescription = pricewatch.ProductDescription,
                    ProductName = pricewatch.ProductName
                };
                // add all entries
                viewModel.Entries = new List<PriceWatchEntryViewModel>();

                //sort by date descending (latest first)
                foreach (var entry in pricewatch.Entries.OrderByDescending(d => d.Date))
                {
                    //create view model for the entry
                    var viewModelEntry = new PriceWatchEntryViewModel()
                    {
                        Date = entry.Date,
                        Id = entry.Id,
                        Price = entry.Price,
                        PriceIndicator = entry.PriceIndicator
                    };

                    viewModel.Entries.Add(viewModelEntry);
                }

                // add view model to the view model list
                viewLst.Add(viewModel);
            }
            // update the database if needed
            if (saveChanges)
            {
                _priceWatchRepository.Save();
            }
            // return the viewModel list to the view 
            return View("PriceWatchView", viewLst);
        }

        //public Task<RedirectToRouteResult> Create(long productId, string productName, string productDescription, string imageUrl) // it was created because of the create test method.
        //{
        //    throw new NotImplementedException();
        //}    

        // GET: PriceWatch/Create
        public ActionResult Create(long productId, decimal price, string productName, string productDescription, string imageUrl, string query, int offset)
        {
            try
            {
                //Create new price watch for the product
                PriceWatch ett = new PriceWatch();

                //current date
                ett.CreationDate = DateTime.Now;

                //indicator to enable/disable this entry, not being used at the moment
                ett.Enabled = true;

                ett.ProductId = productId;

                // get current user
                ett.UserId = _currentUser.Id;

                // must save this basic information so we don't have to use the api everytime
                ett.ProductName = productName;
                ett.ProductDescription = productDescription;
                ett.ImageUrl = imageUrl;


                // add a new entry with todays date informing the price
                ett.Entries = new List<PriceWatchEntry>();
                ett.Entries.Add(new PriceWatchEntry() { Date = ett.CreationDate, Price = price, PriceIndicator = PriceIndicator.Same });

                // add to the database
                _priceWatchRepository.Create(ett);
                _priceWatchRepository.Save();

                // show the same page to the user, now with the price watch added (green)
                return RedirectToAction("Get", "Product", new { query = query, offset = offset });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: PriceWatch/Delete/5
        public ActionResult Remove(long id)
        {
            try
            {
                // remove price by id 
                _priceWatchRepository.Remove(id);
                _priceWatchRepository.Save();

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }
    }
}
