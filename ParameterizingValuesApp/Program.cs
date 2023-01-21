using ParameterizingValuesApp.Classes;
using ParameterizingValuesApp.Data;
using ParameterizingValuesApp.Models;

namespace ParameterizingValuesApp
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            var (success, exception) = await SetupDatabase.CreateDatabase();
            if (success)
            {
                await InsertNewBook();
                Console.WriteLine();

                await EditExistingBook();
                Console.WriteLine();

                await EditExistingBookPeek();
                Console.WriteLine();
                
                await ToQueryStringExample();

                AnsiConsole.MarkupLine("Press[white on blue] ENTER[/] to close");
            }
            else
            {
                AnsiConsole.WriteException(exception);
            }


            Console.ReadLine();
        }

        private static async Task InsertNewBook()
        {
            AnsiConsole.MarkupLine("[white on blue]Adding a new book[/]");

            await using var context = new BookContext();

            decimal value = 1.4m;
            string bookTitle = "My second book";
            int categoryIdentifier = 1;

            context.Books.Add(new Book()
            {
                Price = value, 
                Title = bookTitle, 
                CategoryId = categoryIdentifier, 
                Category = context.Categories.FirstOrDefault(x => x.CategoryId == categoryIdentifier)
            });

            value = 25.5m;
            bookTitle = "EF Core greatest hits";
            categoryIdentifier = 5;

            context.Books.Add(new Book()
            {
                Price = value,
                Title = bookTitle,
                CategoryId = categoryIdentifier,
                Category = context.Categories.FirstOrDefault(x => x.CategoryId == categoryIdentifier)
            });


            Console.WriteLine();
            AnsiConsole.MarkupLine("[white on blue]context.ChangeTracker.DebugView.LongView[/]");

            Console.WriteLine(context.ChangeTracker.DebugView.LongView);

            AnsiConsole.MarkupLine($"[white on blue]Record added {(await context.SaveChangesAsync() == 2).RecordAdded()}[/]");

        }


        private static async Task EditExistingBook()
        {
            AnsiConsole.MarkupLine("[white on blue]Editing existing book[/]");

            await using var context = new BookContext();

            int identifier = 1;

            Book book = await context.Books.FirstOrDefaultAsync(b => b.Id == identifier);
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

            int identifier = 1;

            AnsiConsole.MarkupLine("[white on blue]Editing existing book, peek a original and current value[/]");
            await using var context = new BookContext();

            Book book = await context.Books.AsTracking().FirstOrDefaultAsync(b => b.Id == identifier);

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


            AnsiConsole.MarkupLine($"[black on yellow]Original value[/] {original}");

            var current = context
                .Entry(book)
                .Property(product => product.Price)
                .CurrentValue;

            AnsiConsole.MarkupLine($"[black on yellow]Current value[/] {current}");

            
            AnsiConsole.MarkupLine($"[white on blue]Record updated {(await context.SaveChangesAsync() == 1).RecordAdded()}[/]");
        }

        private static async Task ToQueryStringExample()
        {
            AnsiConsole.MarkupLine("[black on yellow]ToQueryStringExample[/]");

            await using var context = new BookContext();
            int categoryIdentifier = 1;
            var query = context.Books.Where(x => x.CategoryId == categoryIdentifier).OrderBy(x => x.Title);

            Console.WriteLine(query.ToQueryString());

            query = context.Books.Where(x => x.CategoryId == 1).OrderBy(x => x.Title);
            Console.WriteLine(query.ToQueryString());
        }
    }
}