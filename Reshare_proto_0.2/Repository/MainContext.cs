using Microsoft.EntityFrameworkCore;
using Reshare_proto_0._2.Models;

namespace Reshare_proto_0._2.Repository
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationModel>()
                .HasOne<UserModel>(l => l.User)
                .WithOne(u => u.Location)
                .HasForeignKey<UserModel>(u => u.LocationId);

            modelBuilder.Entity<CountryModel>()
                .HasOne<LocationModel>(c => c.Location)
                .WithOne(l => l.Country)
                .HasForeignKey<CountryModel>(l => l.CountryId);

            modelBuilder.Entity<CountryModel>()
                .HasOne<StateModel>(c => c.State)
                .WithOne(s => s.Country)
                .HasForeignKey<CountryModel>(s => s.CountryId);

            modelBuilder.Entity<StateModel>()
                .HasOne<CityModel>(s => s.City)
                .WithOne(c => c.State)
                .HasForeignKey<StateModel>(c => c.StateId);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<CountryModel> Country { get; set; }
        public DbSet<StateModel> State { get; set; }
        public DbSet<CityModel> City { get; set; }
    }
}
