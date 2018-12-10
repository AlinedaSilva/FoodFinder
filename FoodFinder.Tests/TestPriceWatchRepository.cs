using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFinder.Models;

namespace FoodFinder.Tests
{
    class TestPriceWatchRepository: IPriceWatchRepository

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
