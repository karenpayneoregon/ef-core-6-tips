using SecurityDriven.Inferno.Extensions;
using ValueConversionsEncryptProperty.Classes;
using ValueConversionsEncryptProperty.Data;
using ValueConversionsEncryptProperty.Models;

namespace ValueConversionsEncryptProperty
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            var users = BogusOperations.MockedUsers(3);
            AnsiConsole.MarkupLine("[cyan]Bogus/original data[/]");
            users.ForEach(current =>
            {
                Console.WriteLine($"{current.Name,-12}{current.Password}");
            });

            Console.WriteLine();

            await using (var context = new SampleDbContext())
            {
                AnsiConsole.MarkupLine("[cyan]Creating database[/]");
                SetupDatabase.CleanDatabase(context);
                AnsiConsole.MarkupLine("[cyan]Database created...[/]");

                AnsiConsole.MarkupLine("[cyan]Save a new entity...[/]");

                context.AddRange(users);
                await context.SaveChangesAsync();

            }

            Console.WriteLine();

            await using (var context = new SampleDbContext())
            {
                AnsiConsole.MarkupLine("[cyan]Read the entity back[/]");

                context.User.ToList().ForEach(current =>
                {
                    Console.WriteLine($"{current.Name,-12}{current.Password}");
                });
            }


            Console.ReadLine();
        }
    }
}