using Microsoft.EntityFrameworkCore;
using PharmaM.Core.Contracts;
using PharmaM.Data;
using PharmaM.Infrastructure.Data.Models;

namespace PharmaM.Core.Services
{
    public class ProductService:IProductService
    {
        private readonly PharmaMDbContext context;

        public ProductService(PharmaMDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> Filter(int? minPrice, int? maxPrice)
        {
               var filteredProducts = await context.Products
                .Where(p => (minPrice == null || p.Price >= minPrice)
                && (maxPrice == null || p.Price <= maxPrice))
                .ToListAsync();

            return filteredProducts;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var data = await context.Products.ToListAsync();
            return data;
        }

        public async  Task<Product> GetProductById(int id)
        {
            var data = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return data;
        }

        public async Task<IEnumerable<Product>> Search(string searchString)
        {
            var data = await GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                string filter = searchString.ToLower();
                var matches = data.Where(p => p.Name.ToLower().Contains(filter));
                return matches;

            }
            return data;
        }

        public async Task<IEnumerable<Product>> Sort(string order)
        {
            var data = await GetAllAsync();
            if (string.IsNullOrEmpty(order))
            {
                return data;
            }
            return order.ToLower() switch
            {
                "nameasc" => data.OrderBy(p => p.Name),
                "namedesc" => data.OrderByDescending(p => p.Name),
                "priceasc" => data.OrderBy(p => p.Price),
                "pricedesc" => data.OrderByDescending(p => p.Price),
                _ => data,// If the order is not recognized, return the original data
            };

        }
    }
}
