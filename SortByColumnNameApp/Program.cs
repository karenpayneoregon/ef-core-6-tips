using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SortByColumnNameApp.Classes;
using SortByColumnNameApp.Data;
using SortByColumnNameApp.Models;


namespace SortByColumnNameApp;

internal partial class Program
{
    private const int Count = 50;

    static async Task Main(string[] args)
    {
        // Run these once
        //Setup.CleanDatabase();
        //Setup.Populate();

        await DataOperations.SortCustomerOnCountryName();
        await DataOperations.SortCustomerOnContactLastName();
        await DataOperations.SortCustomerOnContactTitle();
        DataOperations.ConventionalOrderByOnNavigation();

        var modelNames = GetOperations.GetDatabaseModels();
        GetOperations.GetProperties(modelNames);
        GetOperations.NavigationDetails();

        ExitPrompt();
        Console.ReadLine();
    }
}