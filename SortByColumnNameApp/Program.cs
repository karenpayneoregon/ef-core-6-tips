using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SortByColumnNameApp.Classes;
using SortByColumnNameApp.Data;
using SortByColumnNameApp.Models;


namespace SortByColumnNameApp;

internal partial class Program
{
    private const int Count = 50;

    static void Main(string[] args)
    {
        // Run these once
        //Setup.CleanDatabase();
        //Setup.Populate();

        //SortCustomerOnCountryName();
        //SortCustomerOnContactLastName();
        //SortCustomerOnContactTitle();

        using var context = new NorthWindContext();
        var customers = context.Customers
            .Include(c => c.Contact)
            .Include(c => c.ContactTypeNavigation)
            .OrderBy(c => c.ContactTypeNavigation.ContactTitle)
            .ToList();


        ExitPrompt();
        Console.ReadLine();
    }

    private static void SortCustomerOnCountryName()
    {
        using var context = new NorthWindContext();
        List<Customers> customers = context.Customers
            .Include(c => c.CountryNavigation)
            .OrderByEnum(BaseProperty.CountryName, Direction.Ascending)
            .ToList();
    

        var table = CreateTableForCountries();

        for (int index = 0; index < Count; index++)
        {
            table.AddRow(customers[index].CompanyName, customers[index].CountryNavigation.Name);
        }

        AnsiConsole.Write(table);
    }

    private static void SortCustomerOnContactLastName()
    {
        using var context = new NorthWindContext();
        List<Customers> customers = context.Customers
            .Include(c => c.Contact)
            .OrderByEnum(BaseProperty.LastName, Direction.Descending)
            .ToList();

        var table = CreateTableForContacts();

        for (int index = 0; index < Count; index++)
        {
            table.AddRow(customers[index].CompanyName, customers[index].Contact.LastName);
        }

        AnsiConsole.Write(table);
    }

    private static void SortCustomerOnContactTitle()
    {
        using var context = new NorthWindContext();
        List<Customers> customers = context.Customers
            .Include(c => c.Contact)
            .Include(c => c.ContactTypeNavigation)
            .OrderByEnum(BaseProperty.Title, Direction.Descending)
            .ToList();

        var table = CreateTableForContactTitle();

        for (int index = 0; index < Count; index++)
        {
            table.AddRow(customers[index].CompanyName, customers[index].ContactTypeNavigation.ContactTitle, customers[index].Contact.LastName);
        }

        AnsiConsole.Write(table);
    }
}