using PharmaM.Core.Contracts;
using PharmaM.Core.Models.Category;
using PharmaM.Data;
using PharmaM.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaM.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PharmaMDbContext context;

        public CategoryService(PharmaMDbContext context)
        {
            this.context = context;
        }

        public async Task AddCategoryAsync(CategoryViewModel model)
        {
            Category newCategory = new Category
            {
                Id = model.Id,
                Name = model.Name
            };

            await context.AddAsync(newCategory);
            await context.SaveChangesAsync();
        }
    }
}
