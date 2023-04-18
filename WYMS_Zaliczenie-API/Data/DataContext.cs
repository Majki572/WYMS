using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using WYMS_Zaliczenie_API.Entities;

namespace WYMS_Zaliczenie_API.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DataContext() { }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.Warehouse)
                .WithMany(w => w.Workers)
                .HasForeignKey(w => w.Warehouses_ID);

            modelBuilder.Entity<Worker>()
                .HasOne(w => w.Vehicle)
                .WithMany(v => v.Workers)
                .HasForeignKey(w => w.Vehicles_ID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Warehouse)
                .WithMany(w => w.Products)
                .HasForeignKey(p => p.Warehouses_ID);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Warehouse)
                .WithMany(w => w.Schedules)
                .HasForeignKey(s => s.Warehouses_ID);

            modelBuilder.Entity<Shop>()
                .HasOne(s => s.Schedule)
                .WithMany(sc => sc.Shops)
                .HasForeignKey(s => s.Schedules_ID);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Shop)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.Shops_ID);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Warehouse)
                .WithMany(w => w.Payments)
                .HasForeignKey(p => p.Warehouses_ID);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Warehouse)
                .WithMany(w => w.Vehicles)
                .HasForeignKey(v => v.Warehouses_ID);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Schedule)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.Schedules_ID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder oB) {
            string connectionString = "Data Source=Database/DBsql.db";
            oB.UseSqlite(connectionString);
        }
    }
}