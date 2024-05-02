using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PharmaM.Infrastructure.Data.Common.DataConstants;


namespace PharmaM.Infrastructure.Data.Models;

[Comment("Application User")]
public class ApplicationUser : IdentityUser
{
    [Comment("First Name User")]
    [Required]
    [Display(Name = "First Name")]
    [MaxLength(UserNameMaxLength)]
    public string FirstName { get; set; } = string.Empty;

    [Comment("Last Name User")]
    [Required]
    [Display(Name = "Last Name")]
    [MaxLength(UserNameMaxLength)]
    public string LastName { get; set; } = string.Empty;


    [Comment("Address User for delivery")]
    [Required]
    public string Address { get; set; } = string.Empty;

    [Comment("Phone Number User")]
    [Required]
    public string Phone { get; set; } = string.Empty;

    public List<Order> Orders { get; set; } = new List<Order>();
}