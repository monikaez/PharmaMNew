using Microsoft.EntityFrameworkCore;
using PharmaM.Core.Contracts;
using PharmaM.Core.Models.Product;
using PharmaM.Core.Models.Category;
using PharmaM.Data;
using PharmaM.Infrastructure.Data.Models;

namespace PharmaM.Core.Services
{
    public class ProductService : IProductService
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
                Description = model.Description,
                NeedsPrescription = model.NeedsPrescription,
                Price = model.Price,
                CategoryId = model.CategoryId,

            };

            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();

          
        }


        public async Task DeleteProductAsync(int id)
        {
            Product product = await context.Products.FindAsync(id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

       

        public async Task EditProductAsync(SingleProductViewModel model)
        {
            var entity = await GetEntityById(model.Id);

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.NeedsPrescription = model.NeedsPrescription;
            entity.ImageURL = model.ImagePath;
            entity.Description = model.Description;
            entity.CategoryId = model.CategoryId;
         

            await context.SaveChangesAsync();
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

        public async Task<Product> GetProductById(int id)
        {
            var data = await context.Products
                .Where(p => p.Id == id)
                .Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageURL = p.ImageURL,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                                       
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

        private async Task<Product> GetEntityById(int id)
        {
            Product? entity = await context.FindAsync<Product>(id);
            if (entity == null)
            {
                throw new ApplicationException("Invalid Product");
            }
            return entity;
        }

      
        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        private async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            var data = await context.Categories.ToListAsync();
            return data;
        }

    }
}
