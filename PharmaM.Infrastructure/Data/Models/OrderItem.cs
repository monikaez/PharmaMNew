using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaM.Infrastructure.Data.Models;

[Comment("Order item")]
public class OrderItem
{
    [Comment("OrderItem Identifire")]
    [Key]
    public int Id { get; set; }

    [Comment("Quantity of order")]
    public int Quantity { get; set; }

    [Comment("Price order")]
    public decimal Price { get; set; }

    //product
    [Comment("Product Identifire")]
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    //order
    [Comment("Order Identifire")]
    public int OrderId { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;
}
