using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using PharmaM.Infrastructure.Data.Common;
using PharmaM.Infrastructure.Data.Models;

namespace PharmaM.Infrastructure.Data.SeedDb;
public class SeedData
{
    //Seeding the default data.
    private readonly ModelBuilder builder;
  
    public SeedData(ModelBuilder builder)
    {
        this.builder = builder;
    }


    public void SeedProduct()
    {
        builder.Entity<Product>()
             .HasData(new List<Product>()
             {
                new Product()
                {
                   Id=1,
                   Name = "Bioderma",
                   ImageURL = "~/images/product_01.png",
                   Description = "Sensibio H2O AR is the 1st make-up removing micellar water that mimics the skin's natural composition for perfect make-up removal and total respect for even the most sensitive skin. It also inhibits redness, by biologically regulating the factor responsible for vasodilation. ",
                   Price = 7,
                   NeedsPrescription = false,
                   CategoryId=5,

                },
                new Product()
                {
                    Id=2,
                    Name = "Chanca Pedra",
                    ImageURL = "~/images/product_02.png",
                    Description = "Experience the phytonutrient power of Swanson Full Spectrum® Chanca Piedra. Chanca piedra has been in use throughout South America, India and China for centuries. Although different species grow and are used in different regions of the world, only Phyllanthus niruri is known to contain the active phytonutrients believed to be responsible for the herb's unique benefits. This herb was used historically to support kidney health, liver health and more!",
                     Price = 11,
                    NeedsPrescription = true,
                    CategoryId=1,

                },
                 new Product()
                 {
                     Id=3,
                     Name = "Umcka ColdCare",
                     ImageURL = "~/images/product_03.png",
                     Description = "Sip on Comforting Care.When you’re feeling sick, enjoying a warm beverage can be a comforting ritual. This homeopathic remedy is clinically proven to shorten the duration and reduce the severity of congestion, cough, sore throat, and nasal and bronchial irritation while providing a soothing, relaxing experience. May also be served cold. For ages 6+.",
                    Price = 5,
                     NeedsPrescription = false,
                     CategoryId=2

                 },
                 new Product()
                 {
                     Id=4,
                     Name = "Umcka® ColdCare Alcohol-Free Drops",
                     ImageURL = "~/images/product_03.png",
                     Description = "Umcka ColdCare Alcohol-Free Drops are clinically proven to shorten the duration and reduce the severity of cough, congestion, sore throat, and nasal and bronchial irritations. The included dropper provides convenient dosage. Take them straight or add drops to a beverage like tea or water to start feeling better, faster. ",
                     Price = 15,
                     NeedsPrescription = false,
                     CategoryId=2

                 },
                 new Product()
                 {
                     Id=5,
                            Name = "Cetyl Pure",
                            ImageURL = "~/images/product_04.png",
                            Description = "As our bodies age, the ability to produce some of the nutrients necessary for joint function and cartilage building declines. CetylPure from “Natrol” helps to nourish and maintain the lubricating fluid in joints and cartilage, which is enough to give you optimal joint health and relief from any joint pain you suffer from, especially after workout sessions.",
                            Price = 25,
                            NeedsPrescription = true,
                            CategoryId=3

                  },
                 new Product()
                  {
                     Id=6,
                     Name = "CLACore",
                     ImageURL = "~/images/product_05.png",
                     Description = "CLA Core Blend - a combination of conjugated linoleic acid, exclusively pure zetin and a small amount of avocado. cla core conjugated linoleic acid has a synergistic effect - the substances increase their effectiveness when used together.",
                      Price = 8,
                     NeedsPrescription = false,
                     CategoryId=4

                 },
                 new Product()
                 {
                     Id=7,
                            Name = "Poo-Pourt",
                            ImageURL = "~/images/product_06.png",
                            Description = "oo-Pourri Before-You-Go Toilet Spray leaves your bathroom smelling fresh and clean. Simply spray the water in the bowl with Poo-Pourri Toilet Spray before using the toilet to prevent odors before they begin! ",
                            Price = 20,
                            NeedsPrescription = true,
                           CategoryId=2,

                  },
                  new Product()
                  {
                      Id=8,
                            Name = "Ibuprofen",
                            ImageURL = "~/images/product_07.png",
                            Description = "Ibuprofen Polfa 200 mg coated tablets is a medicine for the symptomatic treatment of elevated body temperature and pain. It has a beneficial effect on complaints of muscle and menstrual pain, migraine and toothache. The active ingredient of Polpharma Ibuprofen Polfa is ibuprofen, which is a non-steroidal anti-inflammatory drug that is absorbed in the gastrointestinal tract.",
                            Price = 8,
                            NeedsPrescription = false,
                            CategoryId=1,
                  },
                  new Product()
                  {
                      Id=9,
                            Name = "Nurofen Stop Cold",
                            ImageURL = "~/images/product_07.png",
                            Description = "Nurofen StopCold combines the pain-relieving action of ibuprofen with the vasoconstrictor action of pseudoephedrine, relieving pain and symptoms of cold and flu, high fever, sore throat, congestion and runny nose for up to 8 hours.",
                            Price = 8,
                            NeedsPrescription = false,
                            CategoryId=1,
                  },
                   new Product()
                  {
                       Id=10,
                            Name = "Accu Chek Instant glucometer kit + 50 test strips",
                            ImageURL = "~/images/product_07.png",
                            Description = "The Accu-Chek Instant system simplifies testing so patients can understand their results at a glance and have confidence in their daily lives.",
                            Price = 8,
                            NeedsPrescription = false,
                            CategoryId=6,
                  },
                   new Product()
                  {
                       Id=11,
                            Name = "Bionime GM100",
                            ImageURL = "~/images/product_07.png",
                            Description = "Bioname Glucometer GM 100 measures blood sugar quickly and easily. Controls diabetes at home. The meter is accurate and reliable, liked by professionals. The set includes a glucometer and 50 test strips.",
                            Price = 8,
                            NeedsPrescription = false,
                            CategoryId=6,

                  }

             });
    }


    public void SeedUserAndRole()
    {
        // Seed Roles

        List<IdentityRole> roles = new List<IdentityRole>()
        {
        new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
        new IdentityRole { Name = "User", NormalizedName = "USER" }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        // -----------------------------------------------------------------------------

        // Seed Users

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        List<ApplicationUser> users = new List<ApplicationUser>()
        {
     // imporant: don't forget NormalizedUserName, NormalizedEmail 
             new ApplicationUser {
                UserName = "user2@hotmail.com",
                NormalizedUserName = "USER2@HOTMAIL.COM",
                Email = "user2@hotmail.com",
                NormalizedEmail = "USER2@HOTMAIL.COM",
                },

            new ApplicationUser {
                UserName = "user3@hotmail.com",
                NormalizedUserName = "USER3@HOTMAIL.COM",
                Email = "user3@hotmail.com",
                NormalizedEmail = "USER3@HOTMAIL.COM",
                },
            };


        builder.Entity<ApplicationUser>().HasData(users);

        ///----------------------------------------------------

        // Seed UserRoles


        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

        // Add Password For All Users

        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "User.123");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "User.155");

        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[0].Id,
            RoleId =
        roles.First(q => q.Name == "User").Id
        });

        userRoles.Add(new IdentityUserRole<string>
        {
            UserId = users[1].Id,
            RoleId =
        roles.First(q => q.Name == "Admin").Id
        });


        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

    }

}

