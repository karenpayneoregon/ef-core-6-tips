using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecurityDriven.Inferno.Extensions;
using ValueConversionsEncryptProperty.Models;

using static ConfigurationLibrary.Classes.ConfigurationHelper;


namespace ValueConversionsEncryptProperty.Data;

public class SampleDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region ConfigureEncryptPropertyValues
        // Uses NuGet package Inferno
        modelBuilder.Entity<User>().Property(e => e.Password)
            .HasConversion(
                value => value.ToBytes(),
                value => value.FromBytes());
        #endregion

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .LogTo(message => Debug.WriteLine(message),
                new[] { RelationalEventId.CommandExecuted },
                LogLevel.Information,
                DbContextLoggerOptions.UtcTime)
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging();
}