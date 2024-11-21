using System.Collections.Generic;
using System.Reflection.Emit;
using EcoSmart.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoSmart.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<EnergyConsumption> EnergyConsumptions { get; set; }
        public DbSet<EnergyTip> EnergyTips { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置表名
            modelBuilder.Entity<User>().ToTable("USERS");
            modelBuilder.Entity<Device>().ToTable("DEVICES");
            modelBuilder.Entity<EnergyConsumption>().ToTable("ENERGY_CONSUMPTIONS");
            modelBuilder.Entity<EnergyTip>().ToTable("ENERGY_TIPS");
            modelBuilder.Entity<Alert>().ToTable("ALERTS");

            // User -> Device
            modelBuilder.Entity<Device>()
                .HasOne(d => d.User)
                .WithMany(u => u.Devices)
                .HasForeignKey(d => d.UserId);

            // Device -> EnergyConsumption
            modelBuilder.Entity<EnergyConsumption>()
                .HasOne(ec => ec.Device)
                .WithMany(d => d.ConsumptionRecords)
                .HasForeignKey(ec => ec.DeviceId);

            // User -> EnergyConsumption
            modelBuilder.Entity<EnergyConsumption>()
                .HasOne(ec => ec.User)
                .WithMany(u => u.ConsumptionHistory)
                .HasForeignKey(ec => ec.UserId);

            // User -> Alert
            modelBuilder.Entity<Alert>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId);

            // 配置索引
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Device>()
                .HasIndex(d => new { d.UserId, d.Name })
                .IsUnique();
        }
    }
}