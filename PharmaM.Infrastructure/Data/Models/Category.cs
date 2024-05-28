using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static PharmaM.Infrastructure.Data.Common.DataConstants;


namespace PharmaM.Infrastructure.Data.Models;

[Comment("Category Product")]
public class Category
{
    [Comment("Primary key")]
    [Key]
    public int Id { get; set; }

    [Comment("Category Name")]
    [Required]
    [MaxLength(CategoryNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    public List<Product> Products { get; set; } = new List<Product>();

}