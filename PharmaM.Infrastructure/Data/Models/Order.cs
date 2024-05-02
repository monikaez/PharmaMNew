using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PharmaM.Infrastructure.Data.Models;

[Comment("User Order")]
public class Order
{
    [Comment("Order Identifire")]
    [Key]
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime TimeOrdered { get; set; }

    public string StatusOrder { get; set; } = string.Empty;

    //user
    public string UserId { get; set; } = string.Empty;
    [ForeignKey(nameof(UserId))]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    //Order Items
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}