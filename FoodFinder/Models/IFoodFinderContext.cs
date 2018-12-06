using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFinder.Models
{
   public interface IFoodFinderContext: IDisposable
    {
        DbSet<PriceWatch> PriceWatches { get; }
        DbSet<PriceWatchEntry> PriceWatchEntries { get; }
        
        int SaveChanges();
        void MarkAsModified(PriceWatch priceWatch);
        void MarkAsModified(PriceWatchEntry priceWatchEntry);
        object Entry(PriceWatchEntry priceWatchEntry);
    }
}

