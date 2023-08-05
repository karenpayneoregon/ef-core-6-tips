using SqlLiteSimpleApp1.Classes;
using SqlLiteSimpleApp1.Models;

namespace SqlLiteSimpleApp1;

internal partial class Program
{
    static async Task Main(string[] args)
    {

        (List<Person> list, Exception exception) = await PersonOperations.GetAllSafe();
        if (exception is not null)
        {
            Console.WriteLine($"Failed to read data, see log file.");
            Console.ReadLine();
            return;
        }

        AnsiConsole.MarkupLine("[cyan]Current people in the database[/]");
        foreach (var person in list)
        {
            Console.WriteLine($"{person.Id,-3}{person.FirstName,-12}{person.LastName,-12}{person.Pin}");
        }

        Person newPerson = new Person() { FirstName = "Anne", LastName = "Gallagher", Pin = 77777 };
        var affected = await PersonOperations.Add(newPerson).ConfigureAwait(false);
        AnsiConsole.MarkupLine((affected == 1 ?
            $"[green]Save changes was successful[/] Id: [cyan]{newPerson.Id}[/]" :
            "[red]Save changes was not successful[/]"));

        var peopleBeforeChanges = await PersonOperations.GetAll();
        AnsiConsole.MarkupLine("[cyan]Current people in the database[/]");
        foreach (var person in peopleBeforeChanges)
        {
            Console.WriteLine($"{person.Id,-3}{person.FirstName,-12}{person.LastName,-12}{person.Pin}");
        }

        Console.WriteLine();

        int identifier = 1;
        var foundPerson = await PersonOperations.Get(identifier);
        if (foundPerson is not null)
        {
            foundPerson.LastName = "Mills";
            foundPerson.Pin = 22222;
            affected = await PersonOperations.Update(foundPerson).ConfigureAwait(false);
            AnsiConsole.MarkupLine((affected == 1 ?
                "[green]Save changes was successful[/]" :
                "[red]Save changes was not successful[/]"));
        }

        AnsiConsole.MarkupLine("[cyan]Current people in the database[/]");
        
        var peopleAfterChanges = await PersonOperations.GetAll(_lastNameOrdering, OrderingDirection.Ascending);
        foreach (var person in peopleAfterChanges)
        {
            Console.WriteLine($"{person.Id,-3}{person.FirstName,-12}{person.LastName,-12}{person.Pin}");
        }

        if (foundPerson is not null)
        {
            affected = await PersonOperations.Remove(foundPerson);
            Console.WriteLine($"Person should be null {(await PersonOperations.Get(identifier) is null).ToYesNo()}");
        }
        Console.ReadLine();
    }
}