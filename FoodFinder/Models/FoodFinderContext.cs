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
        public void MarkAsModified(PriceWatch priceWatch)
        {
            Entry(priceWatch).State = EntityState.Modified;
        }
    }
}