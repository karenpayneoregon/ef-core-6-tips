using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SortByColumnNameApp;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: NorthWind sort by string";
        Console.WindowHeight = 40;
        Console.WriteLine();
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static Table CreateTableForCountries()
    {
        return new Table()
            .RoundedBorder()
            .BorderColor(Color.LightSlateGrey)
            .AddColumn("[b]Customer[/]")
            .AddColumn("[b]Country[/]")
            .Title("[cyan]By country[/]")
            .Alignment(Justify.Center);
    }

    private static Table CreateTableForContacts()
    {
        return new Table()
            .RoundedBorder()
            .BorderColor(Color.LightSlateGrey)
            .AddColumn("[b]Customer[/]")
            .AddColumn("[b]Contact last name[/]")
            .Title("[cyan]By last name[/]")
            .Alignment(Justify.Center);
    }
    private static Table CreateTableForContactTitle()
    {
        return new Table()
            .RoundedBorder()
            .BorderColor(Color.LightSlateGrey)
            .AddColumn("[b]Customer[/]")
            .AddColumn("[b]Title[/]")
            .AddColumn("[b]Contact last name[/]")
            .Title("[cyan]By title[/]")
            .Alignment(Justify.Center);
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    private static void ExitPrompt()
    {
        Console.WriteLine();
        Render(new Rule($"[white on blue]Press a key to exit the demo[/]")
            .RuleStyle(Style.Parse("cyan"))
            .Centered());
    }
}