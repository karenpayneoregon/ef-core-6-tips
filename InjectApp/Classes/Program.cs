using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace InjectApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Code sample: Dependency Injection";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
            Render(new Rule($"[cyan]Books[/]").RuleStyle(Style.Parse("white")).Centered());
        }

        private static bool DatabaseExists()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal))!.FullName;
            return File.Exists(Path.Combine(path, "EF.BookCatalog.mdf"));
        }
        private static void Render(Rule rule)
        {
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }
        private static Table CreateTable()
        {
            return new Table()
                .RoundedBorder()
                .BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Title[/]")
                .AddColumn("[b]Price[/]")
                .AddColumn("[b]Category[/]")
                .Alignment(Justify.Center);
        }
    }
}
