using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FoodFinder.Models
{
    public class ProductRepository : IProductRepository
    {
        async Task<ProductViewModel> IProductRepository.GetProductAsync(long id)
        {
            // Part of Requesting the product to the tesco api
            var client = new HttpClient();
            var uri = $"https://dev.tescolabs.com/product/?tpnc={id.ToString()}";
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "1f018fcb123847b182d07573e0813f5f");

            var response = await client.GetAsync(uri);
            string responseString = await response.Content.ReadAsStringAsync();
            var product = new ProductViewModel();

            var result = JObject.Parse(responseString);

            if (result != null)
            {
                product = result["products"]?.ToObject<ProductViewModel>();
            }
            return product;
        }
        async Task<IEnumerable<ProductViewModel>> IProductRepository.GetProductsAsync(string query, int offset, int limit)
        {
            var client = new HttpClient();
            var uri = $"https://dev.tescolabs.com/grocery/products/?query={query}&offset={offset.ToString()}&limit={limit.ToString()}";
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "1f018fcb123847b182d07573e0813f5f");

            var response = await client.GetAsync(uri);
            string responseString = await response.Content.ReadAsStringAsync();
            var products = new List<ProductViewModel>();

            var result = JObject.Parse(responseString);

            if (result != null)
            {
                IEnumerable<JToken> results = result["uk"]?["ghs"]?["products"]?["results"]?.Children();
                if (results != null)
                {
                    throw new Exception($"Unexpected Tesco Api response message: {responseString}");
                }
                //// serialize JSON results into .NET objects
                foreach (JToken r in results)
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    ProductViewModel product = r.ToObject<ProductViewModel>();
                    products.Add(product);
                }
            }
            return products;

        }
    }
}