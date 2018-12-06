﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFinder.Models;

namespace FoodFinder.Tests
{
    class TestPriceWatchEntryDbSet: TestDbSet<PriceWatchEntry>
    {
        public override PriceWatchEntry Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
        }
    }
}