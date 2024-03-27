namespace SelectiveUpdatesApp.Classes;

    internal static class Helpers
    {

        public static string Colorize<T>(this string source) where T : new()
        {

            var result = typeof(T)
                .GetProperties()
                .Aggregate(source, (current, p) =>
                    current.Replace(p.Name, $"[green3_1]{p.Name}[/]"));

            result = result.Replace("Originally", "[white on blue]Originally[/]");

            return result;
        }

    }


