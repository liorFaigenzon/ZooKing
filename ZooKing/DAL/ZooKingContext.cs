
using Microsoft.AspNet.Identity.EntityFramework;
using ZooKing.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ZooKing.DAL
{
    public class ZooKingContext :IdentityDbContext<ApplicationUser>
    {

        public ZooKingContext()
            : base("ZooKingContext")
        {
        }

        public DbSet<Zoo> Zoos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Report> Repors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

           // modelBuilder.Entity<Zoo>()
           //.HasMany(p => p.Areas);

           // modelBuilder.Entity<Area>()
           //   .HasRequired<Zoo>(x => x.Zoo);

           // modelBuilder.Entity<Area>()
           //    .HasKey(x => new {x.ID});

           // modelBuilder.Entity<Area>()
           //     .HasMany(p => p.Animals);

           // modelBuilder.Entity<Animal>()
           //     .HasKey(x => new {x.ID });

           // modelBuilder.Entity<Animal>()
           //     .HasRequired(x => x.Area);


            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });        
        }
    }
}




