using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFinder.Models;

namespace FoodFinder.Tests.Repositories
{
    //-----------------------------------------------------------------------------------
    // ****ATTENTION****
    // This is why dependency injection is VERY important
    // We can create a repository implementation that doesn't access the database and can be used just for tests
    // We will pass it to the controller and it won't know the difference
    //-----------------------------------------------------------------------------------
    public class TestPriceWatchRepository: IPriceWatchRepository
    {
        private List<PriceWatch> _priceWatches;

        public TestPriceWatchRepository()
        {
            _priceWatches = new List<PriceWatch>();
        }
        void IPriceWatchRepository.Create(PriceWatch priceWatch)
        {
            _priceWatches.Add(priceWatch);
        }
        IEnumerable<PriceWatch>IPriceWatchRepository.GetPriceWatches(string UserId)
        {
            return _priceWatches.Where(d => d.UserId == UserId);
        }
        void IPriceWatchRepository.Remove(long priceWatchId)
        {
            _priceWatches.RemoveAll(d => d.Id == priceWatchId);
        }
        void IPriceWatchRepository.Save()
        {
            //do nothing 
        }
    }
}
