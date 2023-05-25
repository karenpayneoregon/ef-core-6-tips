using Microsoft.EntityFrameworkCore;
using NorthWindContactsApp.Data;
using Spectre.Console;

namespace NorthWindContactsApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            using var context = new NorthWindContext();

            var contacts = context.Contacts
                .Include(x => x.ContactTypeIdentifierNavigation)
                .Include(x => x.ContactDevices)
                .Take(20)
                .ToList();


            var table = CreateTable();

            foreach (var contact in contacts)
            {
                if (contact.ContactDevices.Any())
                {
                    table.AddRow(contact.ContactId.ToString(), 
                        contact.FirstName, 
                        contact.LastName, 
                        contact.ContactTypeIdentifierNavigation.ContactTitle, 
                        contact.ContactDevices.FirstOrDefault()!.PhoneNumber);
                }
                else
                {
                    table.AddRow(contact.ContactId.ToString(), 
                        contact.FirstName, 
                        contact.LastName, 
                        contact.ContactTypeIdentifierNavigation.ContactTitle, 
                        "[red](none)[/]");
                }
            }

            AnsiConsole.Write(table);
            Console.ReadLine();
        }
        private static Table CreateTable()
        {
            return new Table()
                .RoundedBorder().BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Id[/]")
                .AddColumn("[b]First[/]")
                .AddColumn("[b]Last[/]")
                .AddColumn("[b]Title[/]")
                .AddColumn("[b]Phone[/]")
                .Alignment(Justify.Center)
                .Title("[white on blue]Contacts[/]");
        }
    }
}