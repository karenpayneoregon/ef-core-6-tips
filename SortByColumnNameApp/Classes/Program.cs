using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace SortByColumnNameApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: NorthWind sort by string";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }

        private static Table CreateTableForCountries()
        {
            return new Table()
                .RoundedBorder()
                .BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Customer[/]")
                .AddColumn("[b]Country[/]")
                .Title("By country")
                .Alignment(Justify.Center);
        }

        private static Table CreateTableForContacts()
        {
            return new Table()
                .RoundedBorder()
                .BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Customer[/]")
                .AddColumn("[b]Contact last name[/]")
                .Title("By last name")
                .Alignment(Justify.Center);
        }
    }
}
