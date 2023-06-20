using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopMVC.Data;
using System;
using System.Linq;

namespace ShopMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
             using (var context = new ApplicationDbContext(
             serviceProvider.GetRequiredService<
                 DbContextOptions<ApplicationDbContext>>()))
              {
                   if (context.Users.Any())
                  {
                      return;   // DB has been seeded
                  }
                  context.Users.AddRange(
                      new IdentityUser
                      {
                          UserName = "Superadmin",
                          Email = "Superadmin@gmail.com",
                          PasswordHash = "Admin@1234",
                          EmailConfirmed = true,
                          PhoneNumber = "09356390428",
                          PhoneNumberConfirmed = true
                      }
                      ); 

                  if (!(context.Roles.Where(s => s.Name!.Contains("Superdmin")).Count() > 0))
                  {
                      return;
                  }

                  context.Roles.AddRange(
                      new IdentityRole
                      {
                          Id = "1",
                          Name = "Superadmin",
                          NormalizedName = "Superadmin"
                      });

                  if (!(context.Roles.Where(s => s.Name!.Contains("Superdmin")).Count() > 0))
                      {
                      return;
                      }

                  context.Roles.AddRange(
                  new IdentityRole
                  {
                      Id = "2",
                      Name = "Admin",
                      NormalizedName = "Admin"
                  });

                  if (!(context.UserRoles.Where(s => s.UserId!.Contains("1") && s.RoleId!.Contains("1")).Count() > 0))
                  {
                      return;
                  }

                  context.UserRoles.AddRange(
                      new IdentityUserRole<string>
                      {
                          UserId = "1",
                          RoleId = "1"
                      }
                      ); 
        } 

        }
    }
}
