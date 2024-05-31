using PharmaM.Core.Models.Category;


namespace PharmaM.Core.Contracts
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryViewModel model);
        Task DeleteCategoryAsync(int id);
        Task<CategoryViewModel> GetCategoryByIdAsync(int id);
        Task EditCategoryAsync(CategoryViewModel model);
    }
}
