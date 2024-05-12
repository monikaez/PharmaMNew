using System.ComponentModel.DataAnnotations;
using static PharmaM.Core.Constants.MessageConstants;
using static PharmaM.Infrastructure.Data.Common.DataConstants;

namespace PharmaM.Core.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = null!;
    }
}
