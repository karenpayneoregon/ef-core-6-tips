using SelectiveUpdatesApp.Models;
using System.Reflection;


namespace SelectiveUpdatesApp.Classes;

internal static class Helpers
{

    public static string Colorize(this string source)
    {
        var result = source;
        foreach (PropertyInfo p in typeof(Person).GetProperties())
        {
            result = result.Replace(p.Name, $"[green3_1]{p.Name}[/]");
        }

        return result;
    }
}