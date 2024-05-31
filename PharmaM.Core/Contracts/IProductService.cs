using PharmaM.Core.Models.Category;
using PharmaM.Core.Models.Product;
using PharmaM.Infrastructure.Data.Models;

namespace PharmaM.Core.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> Search(string searchString);
        Task<IEnumerable<Product>> Sort(string order);
        Task<IEnumerable<Product>> Filter(int? minPrice, int? maxPrice);
        Task AddProductAsync(AddProductViewModel model);
        Task EditProductAsync(SingleProductViewModel model);
        Task DeleteProductAsync(int id);

       Task <List<Category>> GetCategories();
    }
}
