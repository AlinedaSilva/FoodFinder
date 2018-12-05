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
        int SaveChanges();
        void MarkAsModified(PriceWatch priceWatch);
    }
}

