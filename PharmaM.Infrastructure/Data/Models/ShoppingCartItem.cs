using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaM.Infrastructure.Data.Models;


[Comment("Shopping Cart Item")]
public class ShoppingCartItem
{
    [Comment("Item for buy identyfire")]
    [Key]
    public int Id { get; set; }

    [Comment("Quantity item")]
    public int Quantity { get; set; }

    //propduct
    [Comment("Product Id")]
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    //shopping cart
    [Comment("ShoppingCart identyfire")]
    public int ShoppingCartId { get; set; }
    [ForeignKey(nameof(ShoppingCartId))]
    public ShoppingCart ShoppingCart { get; set; } = null!;
}
