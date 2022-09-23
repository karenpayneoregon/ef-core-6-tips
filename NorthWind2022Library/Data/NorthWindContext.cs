﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using EntityFrameworkCoreHelpers;
using Microsoft.EntityFrameworkCore;
using NorthWind2022Library.Models;


namespace NorthWind2022Library.Data;

public partial class NorthWindContext : DbContext
{
    public NorthWindContext()
    {
    }

    public NorthWindContext(DbContextOptions<NorthWindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }
    public virtual DbSet<ContactDevices> ContactDevices { get; set; }
    public virtual DbSet<ContactType> ContactType { get; set; }
    public virtual DbSet<Contacts> Contacts { get; set; }
    public virtual DbSet<Countries> Countries { get; set; }
    public virtual DbSet<Customers> Customers { get; set; }
    public virtual DbSet<Employees> Employees { get; set; }
    public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<PhoneType> PhoneType { get; set; }
    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<Region> Region { get; set; }
    public virtual DbSet<Shippers> Shippers { get; set; }
    public virtual DbSet<SupplierRegion> SupplierRegion { get; set; }
    public virtual DbSet<Suppliers> Suppliers { get; set; }
    public virtual DbSet<Territories> Territories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            ConnectionHelpers.StandardLoggingSqlServer(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=NorthWind2022;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.CategoriesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ContactDevicesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ContactTypeConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ContactsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.CountriesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.CustomersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.EmployeesConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrderDetailsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.OrdersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.PhoneTypeConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ProductsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.RegionConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ShippersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.SupplierRegionConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.SuppliersConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.TerritoriesConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}