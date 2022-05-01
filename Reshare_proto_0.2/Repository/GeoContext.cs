using Microsoft.EntityFrameworkCore;
using Reshare_proto_0._2.Models;

namespace Reshare_proto_0._2.Repository
{
    public class GeoContext : DbContext
    {
        public GeoContext(DbContextOptions<GeoContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>()
                .HasMany<StateModel>(s => s.States)
                .WithOne(s => s.Country)
                .IsRequired();
            modelBuilder.Entity<StateModel>()
                .HasMany<CityModel>(s => s.Cities)
                .WithOne(s => s.State)
                .IsRequired();
        }

        public DbSet<CountryModel> Country { get; set; }
        public DbSet<StateModel> State { get; set; }
        public DbSet<CityModel> City { get; set; }
    }
}
