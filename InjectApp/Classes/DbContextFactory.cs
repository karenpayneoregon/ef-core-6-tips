using ConfigurationLibrary.Classes;
using InjectApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace InjectApp.Classes;

public class DbContextFactory : IDesignTimeDbContextFactory<BookContext>
{
    private static string _connectionString;

    public BookContext CreateDbContext()
    {
        return CreateDbContext(null);
    }

    public BookContext CreateDbContext(string[] args)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
        {
            LoadConnectionString();
        }

        var builder = new DbContextOptionsBuilder<BookContext>();

        builder
            .UseSqlServer(_connectionString!)
            .LogTo(message => Debug.WriteLine(message), LogLevel.Information);

        return new BookContext(builder.Options);
    }

    private static void LoadConnectionString()
    {
        _connectionString = ConfigurationHelper.ConnectionString();
    }
}