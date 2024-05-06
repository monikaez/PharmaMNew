using System.ComponentModel.DataAnnotations;
using static PharmaM.Infrastructure.Data.Common.DataConstants;
using static PharmaM.Core.Constants.MessageConstants;
namespace PharmaM.Core.Models.Product;

public class SingleProductViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredMessage)]
    [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength, ErrorMessage = LengthMessage)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = RequiredMessage)]
    public string ImagePath { get; set; } = string.Empty;

    [Required(ErrorMessage = RequiredMessage)]
    [StringLength(DescriptionMaxLength,MinimumLength =DescriptionMinLength,ErrorMessage = LengthMessage)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public bool NeedsPrescription { get; set; }

    [Required]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

}
