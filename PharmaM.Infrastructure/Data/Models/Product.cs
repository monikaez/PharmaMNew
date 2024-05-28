using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static PharmaM.Infrastructure.Data.Common.DataConstants;

namespace PharmaM.Infrastructure.Data.Models;


[Comment("Product for the PharmaM")]
public class Product
{
    [Comment("Primary key")]
    [Key]
    public int Id { get; set; }

    [Comment("Name of the product")]
    [Required]
    [MaxLength(ProductNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [Comment("Image URL of the product")]
    [Required]
    public string ImageURL { get; set; } = string.Empty;

    [Comment("Description of the product")]
    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = string.Empty;


    [Comment("Price the product")]
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }


    [Comment("Needs of Prescription for the product")]
    [Required]
    public bool NeedsPrescription { get; set; }

    [Comment("Category ID of the product")]
    [Required]
    public int CategoryId { get; set; }

    [Required]
    [ForeignKey(nameof(CategoryId))]
    [Comment("Category of the product")]
    public Category Category { get; set; } = null!;
}
