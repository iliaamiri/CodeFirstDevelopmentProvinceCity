using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CodeFirstDevelopmentProvinceCity.Models;

namespace CodeFirstDevelopmentProvinceCity.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Province>().Property(p => p.ProvinceCode).IsRequired();

        builder.Entity<City>().Property(c => c.CityName).IsRequired();

        builder.Entity<Province>().ToTable("Team");
        builder.Entity<City>().ToTable("City");

        builder.Seed();
    }

    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Citie { get; set; }
}
