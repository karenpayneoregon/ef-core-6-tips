# Simple logging for EF Core in Console project

This project demonstrates how to use EF Core 6 logging w/o dependency injection where the options are no logging which is done with creating a new instance of BookContext as per below.


> **Note** The main reason for not using dependency injection is for those developers who are just starting to learn how to work with EF Core. These first timers may have not learned about dependency injection thus ease the learning curve 

```csharp
await using var context = new BookContext();
```

To use logging pass in the log option read from `appsettings.json` see `Log options` section below

```csharp
await using var context = new BookContext(LoggingConfiguration.LoggingOptions());
```


## appsettings.json

Get log option from `EntityFrameWorkLogging.Type`

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
  },
  "EntityFrameWorkLogging": {
    "Type": "NoLogging"
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
| NoLogging | No logging | 
| Debug | Log to Visual Studio's Output window |
| File | File to a file |

## Log to file

In this project when logging to a file the path is, executable path \Logs. To ensure the path exists the following MSBuild command is used in the project file.

```xml
<Target Name="MakeLogFolder" AfterTargets="Build">
   <MakeDir Directories="$(OutDir)Logs" />
</Target>
```

# Read appsettings

The following class is responsible for obtaining `LoggingOptions` which is used to indicate to the DbContext what type of logging to use, Debug, to a file or no logging.

```csharp
/// <summary>
/// Provides access to appsettings.json
/// </summary>
internal class LoggingConfiguration
{
    /// <summary>
    /// Read a specific section
    /// </summary>
    /// <typeparam name="T">model</typeparam>
    /// <param name="section">section to get information</param>
    /// <returns>section strong typed</returns>
    private static T InitOptions<T>(string section) where T : new() 
        => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            .GetSection(section)
            .Get<T>();

    /// <summary>
    /// Get <see cref="LoggingOptions"/> for EF Core 
    /// </summary>
    /// <returns></returns>
    public static LoggingOptions LoggingOptions()
        => InitOptions<EntityFrameWorkLogging>("EntityFrameWorkLogging")
            .Type.GetValueFromEnumMember<LoggingOptions>();
}
```

# DbContext

_loggingOptions defaults to no logging so for the default constructor there is no logging while the overload for the constructor accepts a log option.

```csharp
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
