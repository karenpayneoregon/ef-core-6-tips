using EF_IdentityOptions.Classes;
using EF_IdentityOptions.Data;

using Person = SelectiveUpdatesApp.Models.Person;

namespace EF_IdentityOptions;

internal partial class Program
{
    static void Main(string[] args)
    {
        using var context = new Context();

        CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));

        var success = context.CanConnectAsync(cancellationTokenSource.Token);

        if (success == false)
        {
            AnsiConsole.MarkupLine("[cyan]Creating and populating database[/]");
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.AddRange(BogusOperations.People());
            context.SaveChanges();
            Console.Clear();
        }

        AnsiConsole.MarkupLine("[cyan]List of people[/]");

        List<Person> list = context.Person.ToList();
        for (var index = 0; index < list.Count; index++)
        {

            var person = list[index];
            if (index.IsEven())
            {
                AnsiConsole.MarkupLine($"[yellow]{person.Id,-8}{person.Title,-40}{person.FirstName,-10}{person.LastName,-10}[/]");
            }
            else
            {
                Console.WriteLine($"{person.Id,-8}{person.Title,-40}{person.FirstName,-10}{person.LastName,-10}");
            }
        }


        ExitPrompt();
    }
}