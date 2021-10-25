using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public static class ConfigureDb
    {
        public static void ConfigureTables(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(p => p.Comments).WithOne(p => p.Product);
            modelBuilder.Entity<Product>().HasMany(p => p.Extras).WithOne(p => p.Product);
            modelBuilder.Entity<Product>().HasMany(p => p.Specials).WithOne(p => p.Product);
            modelBuilder.Entity<Pic>().HasMany(p => p.Products).WithOne(p => p.Picture);
            modelBuilder.Entity<PossibleExtras>().HasMany(p => p.ExtraValues).WithOne(p => p.PossibleExtra);
            modelBuilder.Entity<Extra>().HasMany(p => p.ExtraValues).WithOne(p => p.Extra);
        }
    }
}
