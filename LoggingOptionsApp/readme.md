# Simple logging for EF Core in Console project

**TODO**


## appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Type": "Debug"
    }
  },
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Development",
    "Development": "Server=(localdb)\\mssqllocaldb;Database=EF.CatalogLogging;Trusted_Connection=True",
    "Stage": "Stage connection string goes here",
    "Production": "Prod connection string goes here"
  }
}
```

# Log options

```csharp
namespace EntityFrameworkCoreHelpers.Models;

public enum LoggingOptions
{
    NoLogging,
    Debug,
    File
}
```
</br>

| Member        |   Description    |
|:------------- |:-------------|
| NoLogging | TODO | 
| Debug | TODO |
| File | TODO |

# DbContext

```csharp
using System.Diagnostics;
using EntityFrameworkCoreHelpers;
using EntityFrameworkCoreHelpers.Models;
using LoggingOptionsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace LoggingOptionsApp.Data;

public class BookContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    private LoggingOptions _loggingOptions = LoggingOptions.NoLogging;
    public BookContext(LoggingOptions logOption)
    {
        _loggingOptions = logOption;
    }

    public BookContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        switch (_loggingOptions)
        {
            case LoggingOptions.NoLogging:
                NoLogging(optionsBuilder);
                break;
            case LoggingOptions.Debug:
                StandardLogging(optionsBuilder);
                break;
            case LoggingOptions.File:
                ToFileLogging(optionsBuilder);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasComment("Category identifier");
            entity.Property(e => e.Description).HasComment("Category description");
        });
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
    private static void ToFileLogging(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(ConnectionString())
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextLogger().Log)
            .EnableDetailedErrors();

    }
}
```
