﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFinder.Models
{
    interface IProductRepository
    {
        Task<ProductViewModel> GetProductAsync(long id);
        Task<IEnumerable<ProductViewModel>> GetProductsAsync(string query, int offset, int limit = 10);
    }
}