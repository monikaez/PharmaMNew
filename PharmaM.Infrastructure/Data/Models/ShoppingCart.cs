using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmaM.Infrastructure.Data.Models;

public class ShoppingCart
{
    [Key]
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }
    //user
    public string? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    //shoppingcart item
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}