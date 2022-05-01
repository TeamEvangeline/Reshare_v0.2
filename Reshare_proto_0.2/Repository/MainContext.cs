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
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        //public DbSet<ImageCategoryModel> ImageCategories { get; set; }
    }
}
