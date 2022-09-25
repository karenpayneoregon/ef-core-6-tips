using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoreHelpers;
using SortByColumnNameApp.Data;

namespace SortByColumnNameApp.Classes
{
    internal class GetOperations
    {
        public static List<string> GetDatabaseModels()
        {
            using var context = new NorthWindContext();

            return context.GetModelNames().Select(x => x.Name).ToList();
        }

        public static void GetProperties(List<string> modelNames)
        {
            using var context = new NorthWindContext();
            
            foreach (var name in modelNames)
            {
                var table = CreateTable(name);
                
                var properties = context.GetModelProperties(name);

                foreach (var property in properties)
                {
                    table.AddRow(property.Name, property.IsPrimaryKey.ToYesNo());
                }

                AnsiConsole.Write(table);
            }
        }

        private static Table CreateTable(string modelName)
        {
            return new Table()
                .Title($"[cyan]{modelName}[/]")
                .RoundedBorder()
                .BorderColor(Color.LightSlateGrey)
                .AddColumn("[b]Column[/]")
                .AddColumn("[b]Primary[/]")
                .Alignment(Justify.Center);
        }
    }
}
