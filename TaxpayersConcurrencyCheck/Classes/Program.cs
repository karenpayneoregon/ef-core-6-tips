using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace TaxpayersConcurrencyCheck
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Code sample: EF Core get property original and current values";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }

        public static Table CreateTaxpayerChangesViewTable()
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
