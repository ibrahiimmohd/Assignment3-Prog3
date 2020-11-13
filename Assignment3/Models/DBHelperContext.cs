using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment3.Models
{
    public partial class DBHelperContext : DbContext
    {
        public DBHelperContext()
        {
        }

        public DBHelperContext(DbContextOptions<DBHelperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fruit> Fruit { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // replace your local server/db here
                string server_name = "DESKTOP-1MLROAQ";
                string db_name = "master";
                optionsBuilder.UseSqlServer($"Server={server_name};Database={db_name};Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.Property(e => e.FruitId).HasColumnName("FruitID");

                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.Property(e => e.PlanetId).HasColumnName("PlanetID");

                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
