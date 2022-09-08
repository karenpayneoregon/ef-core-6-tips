using System.Diagnostics;
using EntityFrameworkCoreHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using ParameterizingValuesApp.Models;

using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace ParameterizingValuesApp.Data;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DatabaseCategoryLogging(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    /// <summary>
    /// Setup connection for no logging and no change tracking
    /// </summary>
    public static void NoLogging(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(ConnectionString())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    }

    /// <summary>
    /// Setup connection
    /// Log to Visual Studio's output window
    /// </summary>
    public static void StandardLogging(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message));

    }

    /// <summary>
    /// Setup connection
    /// Slimmed down to specific details
    /// </summary>
    private static void DatabaseCategoryLogging(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message),
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information,
                DbContextLoggerOptions.UtcTime);

    }

    /// <summary>
    /// Setup connection
    /// Writes/appends to a file
    /// </summary>
    private static void CustomLogging(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextLogger().Log)
            .EnableDetailedErrors();

    }
}