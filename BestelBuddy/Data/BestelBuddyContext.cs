using Microsoft.EntityFrameworkCore;
using BestelBuddy.Models;

namespace BestelBuddy.Data
{
    public class BestelBuddyContext : DbContext
    {
        public BestelBuddyContext(DbContextOptions<BestelBuddyContext> options)
            : base(options) { }

        public DbSet<Foodtruck> Foodtrucks { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuKaart> MenuKaarten { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Bezoeker> Bezoekers { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<Planner> Planners { get; set; }
        public DbSet<Evenement> Evenementen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Foodtruck → MenuItems (1:n)
            modelBuilder.Entity<Foodtruck>()
                .HasMany(f => f.MenuItems)
                .WithOne(mi => mi.Foodtruck)
                .HasForeignKey(mi => mi.FoodtruckId);

            // Bezoeker → Bestellingen (1:n)
            modelBuilder.Entity<Bezoeker>()
                .HasMany(b => b.Bestellingen)
                .WithOne(b => b.Bezoeker)
                .HasForeignKey(b => b.BezoekerId);

            // Foodtruck → Bestellingen (1:n)
            modelBuilder.Entity<Foodtruck>()
                .HasMany(f => f.Bestellingen)
                .WithOne(b => b.Foodtruck)
                .HasForeignKey(b => b.FoodtruckId);

            // MenuItem discriminators (TPH inheritance)
            modelBuilder.Entity<MenuItem>()
                .HasDiscriminator<string>("MenuItemType")
                .HasValue<Drank>("Drank")
                .HasValue<Snack>("Snack")
                .HasValue<Hoofdgerecht>("Hoofdgerecht")
                .HasValue<Dessert>("Dessert");

            // MenuItem prijs als decimal
            modelBuilder.Entity<MenuItem>()
                .Property(mi => mi.Prijs)
                .HasColumnType("decimal(18,2)");

            // Foodtruck properties
            modelBuilder.Entity<Foodtruck>()
                .Property(f => f.Naam)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Foodtruck>()
                .Property(f => f.Specialiteit)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Foodtruck>()
                .Property(f => f.IsBeschikbaar)
                .HasDefaultValue(false);

            // Foodtruck → MenuKaart (1:1)
            modelBuilder.Entity<Foodtruck>()
                .HasOne(f => f.Menukaart)
                .WithOne(m => m.Foodtruck)
                .HasForeignKey<MenuKaart>(m => m.FoodtruckId);

            // Foodtruck → Medewerkers (1:n)
            modelBuilder.Entity<Foodtruck>()
                .HasMany(f => f.Medewerkers)
                .WithOne(m => m.Foodtruck)
                .HasForeignKey(m => m.FoodtruckId);

            modelBuilder.Entity<Foodtruck>()
                .Navigation(f => f.Medewerkers)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
