using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vehicle_Configurator.Domain.Entities;
using Vehicle_Configurator.Domain.Enums;

namespace Vehicle_Configurator.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Segment> Segment { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<SgMfgMaster> SgMfgMaster { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<VehicleDetail> VehicleDetail { get; set; }
        public DbSet<Component> Component { get; set; }
        public DbSet<AlternateComponentMaster> AlternateComponentMaster { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeader { get; set; }
        public DbSet<User> User { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlternateComponentMaster>()
                .HasOne(a => a.Component) // maps to CompId
                .WithMany(c => c.DefaultComponents)
                .HasForeignKey(a => a.CompId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AlternateComponentMaster>()
                .HasOne(a => a.AltComponent) // maps to AltCompId
                .WithMany(c => c.AltComponents)
                .HasForeignKey(a => a.AltCompId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            var converter = new EnumToStringConverter<ComponentType>();
            // Apply the custom value converter for the CompType enum
            // This tells Entity Framework to convert the ComponentType enum to a string
            // when reading from and writing to the database.
            modelBuilder.Entity<VehicleDetail>()
               .Property(v => v.CompType)
               .HasConversion(converter);

        }

    }


}
