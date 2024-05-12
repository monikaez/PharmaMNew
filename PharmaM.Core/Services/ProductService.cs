using Microsoft.EntityFrameworkCore;
using PharmaM.Core.Contracts;
using PharmaM.Core.Models.Product;
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

        public async Task AddProductAsync(AddProductViewModel model)
        {
            Product newProduct = new Product
            {
                Name = model.Name,
                ImageURL = model.ImagePath,
                Description=model.Description,
                NeedsPrescription=model.NeedsPrescription,
                Price=model.Price,
                //Category = model.Categories.Name,
                CategoryId=model.CategoryId,
            };
          
            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();
        }

        
        public  async Task EditProductAsync(SingleProductViewModel model, int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.NeedsPrescription = model.NeedsPrescription;
                product.ImageURL = model.ImagePath;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;
                product.Category.Name = model.CategoryName;
              
                await context.SaveChangesAsync();
            }
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
            var data= await context.Products
                .Where(p => p.Id == id)
                .Select(p=> new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageURL = p.ImageURL,
                    Description = p.Description,
                    CategoryId = p.CategoryId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
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
