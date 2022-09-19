using InjectApp.Classes;
using Microsoft.EntityFrameworkCore;

namespace InjectApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {

        if (DatabaseExists())
        {
            await using var context = new DbContextFactory().CreateDbContext();
            var books = await context.Books.Include(x => x.Category).ToListAsync();

            Table table = CreateTable();

            foreach (var book in books)
            {
                table.AddRow(book.Title, book.Price.ToString("C"), book.Category.Description);
            }

            AnsiConsole.Write(table);

            Console.WriteLine();            
        }
        else
        {
            AnsiConsole.MarkupLine("[white on red]Must create the database[/]");
        }


        //AnsiConsole.MarkupLine("[white on blue]Press a key to exit[/]");
        Console.ReadLine();

    }

}