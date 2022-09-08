namespace ParameterizingValuesApp.Classes;

public static class Extensions
{
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
    public static string RecordAdded(this bool value) 
        => value ? "[white on blue]Yes[/]" : "[white on red]No[/]";
}