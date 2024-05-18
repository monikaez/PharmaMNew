using PharmaM.Core.Models.Category;


namespace PharmaM.Core.Contracts
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryViewModel model);
    }
}
