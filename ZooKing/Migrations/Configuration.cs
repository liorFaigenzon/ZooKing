
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ZooKing.Models;

internal sealed class Configuration : DbMigrationsConfiguration<ZooKing.DAL.ZooKingContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(ZooKing.DAL.ZooKingContext context)
    {
        //-------------------------------------------------------
        if (!context.Roles.Any(r => r.Name == "Admins"))
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole { Name = "Admins" };

            manager.Create(role);
        }
        //-------------------------------------------------------
        if (!context.Users.Any(u => u.UserName == "admin"))
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { UserName = "admin" };

            manager.Create(user, "123456");
            manager.AddToRole(user.Id, "Admins");
        }
        //-------------------------------------------------------

        List<Animal> Animal = new List<Animal>
        {
            new Animal{Name = "horse sea",
                        Age=15},
            new Animal{Name = "sea horse",
                        Age=15
                        }
        };


        List<Area> Area1 = new List<Area>
        {
            new Area{Size = 10,
                        Name="kkk",
                        Animals= Animal}
        };


        context.Zoos.AddOrUpdate(
            p => p.ID,
            new Zoo { Name = "Peter sea world",
                    Addres = "אטלנטה",
                    ShortInfo = "come and enjoy1",
                    YearOfEstablishment = DateTime.Parse("2005-09-01"), 
                    Areas = Area1}
        );
            
    }
}
