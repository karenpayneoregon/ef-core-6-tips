using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaxpayerLibraryEntityVersion.Classes;
using TaxpayerLibraryEntityVersion.Models;
using TaxpayerMocking.Classes;

namespace TaxpayerMocking
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {

            SetupDatabase.Initialize(5);
            List<Taxpayer> taxpayerList = SetupDatabase.GetTaxpayers();

            /*
             * See comments in method
             */
            JsonOperations.Convert(taxpayerList);
            

            var viewTable = CreateTaxpayerViewTable();

            AnsiConsole.Clear();

            foreach (var taxpayer in taxpayerList)
            {
                if (taxpayer.StartDate.HasValue)
                {
                    viewTable.AddRow(taxpayer.Id.ToString(),
                        taxpayer.FullName,
                        taxpayer.SocialSecurityNumber,
                        taxpayer.Pin,
                        taxpayer.StartDate.Value.ToString("MM/dd/yyyy"),
                        taxpayer.Category.Description);
                }
            }

            AnsiConsole.Write(viewTable);
            
            Console.WriteLine();
            AnsiConsole.MarkupLine("[cyan]Get changes, press a key to continue[/]");
            Console.ReadLine();
            AnsiConsole.Clear();

            var changes = await EntityDataOperations.GetOriginalValuesAfterEditingVersion1();

            var changesTable = CreateTaxpayerChangesViewTable();

            foreach (var change in changes)
            {
                changesTable.AddRow(
                    change.PropertyName, 
                    change.OriginalValue.ToString()!, 
                    change.CurrentValue.ToString()!);
            }

            AnsiConsole.Write(changesTable);

            Console.ReadLine();
        }


    }
}