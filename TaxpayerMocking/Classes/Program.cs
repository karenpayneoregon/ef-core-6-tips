using System.Runtime.CompilerServices;
using static ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace TaxpayerMocking
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Code sample: Create/populate database for taxpayers";
            SetConsoleWindowPosition(AnchorWindow.Center);
        }

        private static Table CreateTaxpayerViewTable()
        {
            return new Table()
                .RoundedBorder().BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Id[/]")
                .AddColumn("[b]Name[/]")
                .AddColumn("[b]SSN[/]")
                .AddColumn("[b]PIN[/]")
                .AddColumn("[b]Start date[/]")
                .AddColumn("[b]Category[/]")
                .Alignment(Justify.Center)
                .Title("[white on blue]Taxpayers[/]");
        }

        private static Table CreateTaxpayerChangesViewTable()
        {
            return new Table()
                .RoundedBorder().BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]PropertyName[/]")
                .AddColumn("[b]OriginalValue[/]")
                .AddColumn("[b]CurrentValue[/]")
                .Alignment(Justify.Center)
                .Title("[white on blue]Changes to a taxpayer[/]");
        }
    }
}
