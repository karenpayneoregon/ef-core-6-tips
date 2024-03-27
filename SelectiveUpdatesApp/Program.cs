using Microsoft.EntityFrameworkCore;
using SelectiveUpdatesApp.Data;
using SelectiveUpdatesApp.Models;
using SelectiveUpdatesApp.Classes;

namespace SelectiveUpdatesApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        BaseExample();
        FirstExample();
        SecondExample();

        Console.WriteLine();
        AnsiConsole.MarkupLine("[white on blue]Time to exit[/]");
        Console.ReadLine();
    }

    private static void BaseExample()
    {
        AnsiConsole.MarkupLine($"[cyan]Running[/] [yellow]{nameof(BaseExample)}[/]");

        using Context context = new();
        Person person = context.Person.FirstOrDefault(x => x.Id == 3);

        if (person is not null)
        {       
            person.FirstName = "Billy bob";
            AnsiConsole.MarkupLine(context.ChangeTracker.DebugView.LongView.Colorize<Person>());
            context.SaveChanges();
        }

        AnsiConsole.MarkupLine($"[cyan]Done[/] [yellow]{nameof(BaseExample)}[/]");
    }
    private static void FirstExample()
    {
        AnsiConsole.MarkupLine($"[cyan]Running[/] [yellow]{nameof(FirstExample)}[/]");

        using Context context = new ();
        Person person = context.Person.FirstOrDefault();

        if (person is not null)
        {
            person.FirstName = "James";
            person.LastName = "Adams";
            context.Entry(person).State = EntityState.Modified;
            context.Entry(person).Property(p => p.LastName).IsModified = false;
            // alternates
            //context.Entry(person).Property(nameof(person.LastName)).IsModified = false;
            //context.Entry(person).Property("LastName").IsModified = false;
            context.SaveChanges();
        }

        AnsiConsole.MarkupLine($"[cyan]Done[/] [yellow]{nameof(FirstExample)}[/]");

    }

    private static void SecondExample()
    {
        AnsiConsole.MarkupLine($"[cyan]Running[/] [yellow]{nameof(SecondExample)}[/]");

        using Context context = new ();
        int identifier = 2;
        Person person = new () { Id = identifier };
        PersonModel model = new() { Id = identifier, FirstName = "Kate" };

        context.Attach(person);
        context.Entry(person).CurrentValues.SetValues(model);
        context.SaveChanges();

        AnsiConsole.MarkupLine($"[cyan]Done[/] [yellow]{nameof(SecondExample)}[/]");

    }
}