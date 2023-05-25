using MaxLengthApp.Classes;
using MaxLengthApp.Data;

// ReSharper disable PossibleMultipleEnumeration


namespace MaxLengthApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        using var context = new Context();
        
        var models = context.GetModelNames();

        foreach (var model in models)
        {
            IEnumerable<SqlColumn> columns = context
                .GetModelProperties(model.Name)
                .Where(x => x.ClrType == typeof(string) && x.MaxLength > 0);

            if (columns.Any())
            {
                AnsiConsole.MarkupLine($"[white on blue]{model.Name}[/]");
                foreach (var column in columns)
                {
                    AnsiConsole.MarkupLine($"\t[cyan]{column.Name}[/] [yellow]{column.ClrType.Name}[/] [white]=>[/] [cyan]{column.MaxLength}[/]");
                }
            }
        }

        Console.ReadLine();
    }
}