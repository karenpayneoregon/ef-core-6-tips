using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlLiteSimpleApp1.Models;

namespace SqlLiteSimpleApp1.Data;

public class Context : DbContext
{
    private static IConfiguration? _configuration;
    public DbSet<Person> Person { get; set; }

    public Context()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(_configuration!.GetValue<string>("ConnectionStrings:ApplicationConnection"))
            .EnableSensitiveDataLogging()
            .LogTo(message => Debug.WriteLine(message),
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information,
                DbContextLoggerOptions.UtcTime);
}