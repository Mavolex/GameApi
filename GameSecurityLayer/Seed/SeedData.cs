using GameSecurityLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Member.Data.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new GameContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameContext>>()))
            {
                /*if (context.Users.Any())
                {
                    return;
                }*/

/*                context.Users.AddRange(
                    new UserModel { FirstName = "Kirtesh", LastName = "Shah", Address = "Vadodara", Balance = 100.1F },
                    new UserModel { FirstName = "Nitya", LastName = "Shah", Address = "Vadodara", Balance = 100.1F },
                    new UserModel { FirstName = "Dilip", LastName = "Shah", Address = "Vadodara", Balance = 100.1F },
                    new UserModel { FirstName = "Atul", LastName = "Shah", Address = "Vadodara", Balance = 100.1F },
                    new UserModel { FirstName = "Swati", LastName = "Shah", Address = "Vadodara", Balance = 100.1F },
                    new UserModel { FirstName = "Rashmi", LastName = "Shah", Address = "Vadodara", Balance = 100.1F }
                );
                context.Products.AddRange(
                    new Product { Name = "Adidas Shoes", Price = 122.5F, Avaliable = 2 },
                    new Product { Name = "Adidas Jacket", Price = 87.1F, Avaliable = 4 },
                    new Product { Name = "Adidas T-Shirt", Price = 27.4F, Avaliable = 8 },
                    new Product { Name = "Adidas Pants", Price = 67.3F, Avaliable = 3 },
                    new Product { Name = "Adidas Cap", Price = 21F, Avaliable = 11 }
                );*/
                context.SaveChanges();
            }
        }
    }
}