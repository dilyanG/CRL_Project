using CRL.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataAccess
{
    public class DataContext : DbContext
    {

        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<RouteEntity> Routes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CRL.Database;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityEntity>().ToTable("Cities")
                                            .Property(c => c.CreatedOn)
                                            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RouteEntity>().ToTable("Routes")
                                            .Property(r => r.CreatedOn)
                                            .HasDefaultValueSql("getdate()");
        }
    }
}
