using PharmaM.Core.Models.Category;
using System.ComponentModel.DataAnnotations;
using static PharmaM.Core.Constants.MessageConstants;
using static PharmaM.Infrastructure.Data.Common.DataConstants;

namespace PharmaM.Core.Models.Product
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string ImagePath { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool NeedsPrescription { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

    }
}
