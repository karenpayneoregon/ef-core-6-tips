using EntityFrameworkCoreHelpers;
using ModelCommentsApp.Data;
using ModelCommentsApp.Models;

namespace ModelCommentsApp
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            //await using var context = new BookContext();
            //var books = context.Books.ToList();

            //foreach (var book in books)
            //{
            //    Console.WriteLine(book.Price);
            //}
            await AllModelComments();
            Console.ReadLine();
        }

        private static async Task AllModelComments()
        {
            await using var context = new BookContext();

            var models = context.GetModelNames().Select(x => x.Name);

            var table = CreateTable();
            foreach (var model in models)
            {
                table.AddRow($"[white on blue]{model}[/]");
                var comments = context.Comments(model);
                foreach (var comment in comments)
                {
                    table.AddRow(comment.Name, comment.Comment ?? "[red](none)[/]");
                }

                table.AddEmptyRow();
            }

            AnsiConsole.Write(table);
        }

        private static async Task GetCommentsForBooksModel()
        {
            await using var context = new BookContext();

            var comments = context.Comments(nameof(Book));

            foreach (var comment in comments)
            {
                Console.WriteLine($"{comment.Name}, {comment.Comment ?? "(none)"}");
            }
        }

        private static async Task GetCommentsForCategoryModel()
        {
            await using var context = new BookContext();

            var comments = context.Comments(nameof(Category));

            foreach (var comment in comments)
            {
                Console.WriteLine($"{comment.Name}, {comment.Comment ?? "(none)"}");
            }
        }
    }
}