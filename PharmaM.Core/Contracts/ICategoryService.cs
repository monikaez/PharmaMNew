using PharmaM.Core.Models.Category;
using PharmaM.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaM.Core.Contracts
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryViewModel model);
    }
}
