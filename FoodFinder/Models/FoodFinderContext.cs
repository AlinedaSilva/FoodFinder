using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FoodFinder.Models
{
    public class FoodFinderContext: DbContext, IFoodFinderContext
    {
        public FoodFinderContext() :base ("name=FoodFinderContext")
        {

        }
                     
        public DbSet<PriceWatch> PriceWatches { get; set; }
        public DbSet<PriceWatchEntry> PriceWatchEntries => throw new NotImplementedException(); // for the view testing

        public new object Entry(PriceWatchEntry priceWatchEntry)
        {
            throw new NotImplementedException();
        }

        public void MarkAsModified(PriceWatch priceWatch)
        {
            Entry(priceWatch).State = EntityState.Modified;
        }

        public void MarkAsModified(PriceWatchEntry priceWatchEntry)
        {
            throw new NotImplementedException();
        }
    }
}