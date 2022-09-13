using FoodDonation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonation.DataAccess
{
    public class FoodDonorDbContext : DbContext
    {
        public FoodDonorDbContext(DbContextOptions<FoodDonorDbContext> options) : base(options)
        {

        }

        public DbSet<FoodDonorModels> fooddonor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodDonorModels>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Location).HasColumnName("Location");
                entity.Property(e => e.Number).HasColumnName("Number");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
