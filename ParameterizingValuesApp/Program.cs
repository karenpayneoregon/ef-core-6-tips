using EntityFrameworkCoreHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using ParameterizingValuesApp.Classes;
using ParameterizingValuesApp.Data;
using ParameterizingValuesApp.Models;

namespace ParameterizingValuesApp
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            //var book = context.Books.FirstOrDefault(x => x.Id == 1);
            var (success, exception) = await SetupDatabase.CreateDatabase();
            await Task.Delay(0);
            await InsertNewBook();
            Console.WriteLine();
            AnsiConsole.MarkupLine("Press[white on blue] ENTER[/] to close");
            Console.ReadLine();
        }

        private static async Task InsertNewBook()
        {
            AnsiConsole.MarkupLine("[white on blue]Adding a new book[/]");

            await using var context = new BookContext();

            decimal value = 1.4m;
            string bookTitle = "My second book";
            context.Books.Add(new Book()
            {
                Price = value, 
                Title = bookTitle, 
                CategoryId = 1
            });

            Console.WriteLine();
            Console.WriteLine(context.ChangeTracker.DebugView.LongView);
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[white on blue]Record added {(await context.SaveChangesAsync() == 1).RecordAdded()}[/]");
        }


        private static async Task EditExistingBook()
        {
            AnsiConsole.MarkupLine("[white on blue]Editing existing book[/]");

            await using var context = new BookContext();

            Book book = await context.Books.FirstOrDefaultAsync(b => b.Id == 1);
            if (book is null)
            {
                AnsiConsole.MarkupLine("[white on red]No records found[/]");
                return;
            }

            book!.Price +=1;

            Console.WriteLine(context.ChangeTracker.DebugView.LongView);
            Console.WriteLine();
            AnsiConsole.MarkupLine($"[white on blue]Record updated {(await context.SaveChangesAsync() == 1).RecordAdded()}[/]");
        }
        private static async Task EditExistingBookPeek()
        {

            AnsiConsole.MarkupLine("[white on blue]Editing existing book, peek a original and current value[/]");
            await using var context = new BookContext();

            Book book = await context.Books.AsTracking().FirstOrDefaultAsync(b => b.Id == 1);

            if (book is null)
            {
                AnsiConsole.MarkupLine("[white on red]No records found[/]");
                return;
            }

            book!.Price += 1;

            var original = context
                .Entry(book)
                .Property(product => product.Price)
                .OriginalValue;


            var current = context
                .Entry(book)
                .Property(product => product.Price)
                .CurrentValue;

            Console.WriteLine("Put break point here and examine original and current");
            AnsiConsole.MarkupLine($"[white on blue]Record updated {(await context.SaveChangesAsync() == 1).RecordAdded()}[/]");
        }
    }
}