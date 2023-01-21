﻿
using ParameterizingValuesApp.Data;
using ParameterizingValuesApp.Models;

namespace ParameterizingValuesApp.Classes;

internal class SetupDatabase
{
    /// <summary>
    /// Used to create the database only if it does not exists
    /// Does not populate <see cref="Category"/> table
    /// </summary>
    /// <returns></returns>
    public static async Task<(bool success, Exception exception)> InitialCreateDatabase()
    {
        try
        {
            await using var context = new BookContext();

            var (success, _) = await context.CanConnectAsync();
            if (success) return (true, null);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            return (true, null);
        }
        catch (Exception localException)
        {

            return (false, localException);
        }
    }

    /// <summary>
    /// Used to start over with some <see cref="Category"/> rows
    /// </summary>
    public static async Task<(bool success, Exception exception)> CreateDatabase()
    {
        try
        {
            await using var context = new BookContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            context.Categories.Add(new Category() {  Description = "Action"  });
            context.Categories.Add(new Category() {  Description = "Comedy"  });
            context.Categories.Add(new Category() {  Description = "Fiction" });
            context.Categories.Add(new Category() {  Description = "Learn C#"});
            context.Categories.Add(new Category() {  Description = "EF Core 7"});

            await context.SaveChangesAsync();

            return (true, null);
        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }
}