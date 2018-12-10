using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFinder.Models;

namespace FoodFinder.Tests
{
    class TestPriceWatchDbSet : TestDbSet<PriceWatch>
    {
        public override PriceWatch Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
        }
    }
}
