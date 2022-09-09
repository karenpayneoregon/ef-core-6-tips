using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace ModelCommentsApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: EF Core 6 get comments for model properties";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static Table CreateTable()
        {
            return new Table()
                .RoundedBorder().BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Property[/]")
                .AddColumn("[b]Comment[/]")
                .Alignment(Justify.Center)
                .Title("[white on blue]Model Comments[/]");
        }
    }
}
