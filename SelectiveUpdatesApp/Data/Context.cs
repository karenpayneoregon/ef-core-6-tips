using System.Diagnostics;
using ConfigurationLibrary.Classes;
using EntityFrameworkCoreHelpers;
using Microsoft.EntityFrameworkCore;
using SelectiveUpdatesApp.Models;
#nullable disable

namespace SelectiveUpdatesApp.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            ConnectionHelpers.StandardLoggingSqlServer(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.PersonConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}