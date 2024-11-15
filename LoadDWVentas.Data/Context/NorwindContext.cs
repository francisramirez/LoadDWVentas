﻿


using LoadDWVentas.Data.Entities.Northwind;
using LoadDWVentas.Data.Entities.Norwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDWVentas.Data.Context
{
    public partial class NorwindContext : DbContext
    {
        public NorwindContext(DbContextOptions<NorwindContext> options) : base(options)
        {

        }

        #region"Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Vwventa> Vwventas { get; set; }
        public DbSet<VwServedCustomer> VwServedCustomers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VwServedCustomer>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VW_ServedCustomers", "DWH");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(31);
            });

            modelBuilder.Entity<Vwventa>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VWVentas", "DWH");

                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength()
                    .HasColumnName("CustomerID");
                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(31);
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            });
        }
    }
}
