using Microsoft.EntityFrameworkCore;
using NorthWind2022Library.Classes;
using NorthWind2022Library.Data;
using NorthWind2022Library.Models;


namespace SortByColumnNameApp;

internal partial class Program
{
    private const int Count = 8;

    static void Main(string[] args)
    {
        SortCustomerOnCountryName();
        SortCustomerOnContactLastName();
        AnsiConsole.MarkupLine("[white on blue]Done[/]");
        Console.ReadLine();
    }

    private static void SortCustomerOnCountryName()
    {
        using var context = new NorthWindContext();
        List<Customers> customers = context.Customers
            .Include(c => c.CountryNavigation)
            .OrderByString("CountryName")
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
            .OrderByString("LastName", Direction.Descending)
            .ToList();

        var table = CreateTableForContacts();

        for (int index = 0; index < Count; index++)
        {
            table.AddRow(customers[index].CompanyName, customers[index].Contact.LastName);
        }

        AnsiConsole.Write(table);
    }
}