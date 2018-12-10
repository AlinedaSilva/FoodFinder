using System;
using System.Data.Entity;
using FoodFinder.Models;

namespace FoodFinder.Tests
{
    class TestApplicationDbContext:IFoodFinderContext
    {
        //private IPriceWatchRepository @object;

        //public DbSet<FoodFinder.Models.PriceWatch> PriceWatches { get; set; }
        
        public TestApplicationDbContext()
        {
        }

        private DbSet<PriceWatchEntry> TestPriceWatchEntryDbSet()
        {
            throw new NotImplementedException();
        }

        public DbSet<PriceWatch> PriceWatches { get; set; }
        public DbSet<PriceWatchEntry> PriceWatchEntries { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(PriceWatch item) { }
        public void MarkAsModified(PriceWatchEntry priceWatchItem) { }
        public void Dispose() { }

        public object Entry(PriceWatchEntry priceWatchEntry)
        {
            throw new NotImplementedException();
        }
    }
}

