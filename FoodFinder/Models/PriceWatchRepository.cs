using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodFinder.Models
{ 
    public class PriceWatchRepository : IPriceWatchRepository
{
    private ApplicationDbContext _db = new ApplicationDbContext();

    public PriceWatchRepository()
    {

    }

    void IPriceWatchRepository.Create(PriceWatch priceWatch)
    {
        _db.PriceWatches.Add(priceWatch);
    }

    IEnumerable<PriceWatch> IPriceWatchRepository.GetPriceWatches(string userId)
    {
        return _db.PriceWatches.Include(pw => pw.Entries).Where(d => d.UserId == userId && d.Enabled);
    }

    void IPriceWatchRepository.Remove(long id)
    {
        var ett = _db.PriceWatches.Include(d => d.Entries).Where(d => d.Id == id).FirstOrDefault();

        if (ett != null)
        {
            ett.Entries?.Clear();
            _db.PriceWatches.Remove(ett);
        }
    }

    void IPriceWatchRepository.Save()
    {
        _db.SaveChanges();
    }
}
}

