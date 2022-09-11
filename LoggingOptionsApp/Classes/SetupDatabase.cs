using EntityFrameworkCoreHelpers;
using EntityFrameworkCoreHelpers.Models;
using LoggingOptionsApp.Data;
using LoggingOptionsApp.Models;

namespace LoggingOptionsApp.Classes;

internal class SetupDatabase
{
 
    /// <summary>
    /// Used to start over with some <see cref="Category"/> rows
    /// </summary>
    public static async Task<(bool success, Exception exception)> CreateDatabase()
    {
        
        AnsiConsole.MarkupLine($"[white on blue]Log option [/][yellow on blue]{LoggingConfiguration.LoggingOptions()}[/]");

        try
        {
            await using var context = new BookContext(LoggingConfiguration.LoggingOptions());
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            context.Categories.Add(new Category() { Description = "Action" });
            context.Categories.Add(new Category() { Description = "Comedy" });
            context.Categories.Add(new Category() { Description = "Fiction" });
            context.Categories.Add(new Category() { Description = "Learn C#" });
            context.Categories.Add(new Category() { Description = "EF Core 6" });

            await context.SaveChangesAsync();

            AnsiConsole.MarkupLine("[white on blue]Database created[/]");

            return (true, null);
        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }
}