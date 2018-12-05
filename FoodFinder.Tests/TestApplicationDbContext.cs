using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FoodFinder.Models;

namespace FoodFinder.Tests
{
    class TestApplicationDbContext:IFoodFinderContext
    {
      //  public DbSet<FoodFinder.Models.PriceWatch> PriceWatches { get; set; }
        public TestApplicationDbContext()
        {
            this.PriceWatches = new TestPriceWatchDbSet();
        }

        public DbSet<PriceWatch> PriceWatches { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(PriceWatch item) { }
        public void Dispose() { }
    }
}

