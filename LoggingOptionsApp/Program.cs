using LoggingOptionsApp.Classes;
using LoggingOptionsApp.Data;

namespace LoggingOptionsApp
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {

            await SetupDatabase.CreateDatabase();

            await using var context = new BookContext();

            var categories = context.Categories.ToList();

            var table = CreateTable();

            foreach (var category in categories)
            {
                table.AddRow(category.CategoryId.ToString(), category.Description);
            }

            AnsiConsole.Write(table);

            Console.ReadLine();

        }
    }
}