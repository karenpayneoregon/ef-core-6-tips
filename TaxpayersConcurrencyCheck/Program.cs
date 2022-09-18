using Microsoft.EntityFrameworkCore;
using TaxpayerLibraryEntityVersion.Classes;
using TaxpayerLibraryEntityVersion.Models;
using TaxpayersConcurrencyCheck.Classes;

namespace TaxpayersConcurrencyCheck
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            
            await UpdateFavorLocal();
            //await UpdateWithDatabaseValues();
            //await UpdateNot();
            //await PeekChanges();


            Console.WriteLine();
            AnsiConsole.MarkupLine("[black on cyan]Done[/]");
            Console.ReadLine();
        }

        /// <summary>
        /// Shows using database values on <see cref="DbUpdateConcurrencyException"/>
        /// </summary>
        private static async Task UpdateWithDatabaseValues()
        {
            int id = 1;
            var taxpayer = await DataOperations.GetTaxpayerByIdentity(id);

            await DataOperations.OedContext.Database.ExecuteSqlRawAsync(
                "UPDATE dbo.Taxpayer SET FirstName = 'Dummy first name', LastName = 'Dummy last name' " +
                $"WHERE Id = {id}");

            var date = new RandomDateTime();
            taxpayer.FirstName = "Karen";
            taxpayer.LastName = "Payne";
            taxpayer.Pin = "4873";
            taxpayer.StartDate = date.Next();
            var (success, exception) = await DataOperations.UpdateWithCurrentDatabaseValues(taxpayer);
        }

        /// <summary>
        /// Shows using local values on <see cref="DbUpdateConcurrencyException"/>
        /// </summary>
        private static async Task UpdateFavorLocal()
        {
            int id = 1;
            var taxpayer = await DataOperations.GetTaxpayerByIdentity(id);

            await DataOperations.OedContext.Database.ExecuteSqlRawAsync(
                "UPDATE dbo.Taxpayer SET FirstName = 'Dummy first name', LastName = 'Dummy last name' " +
                $"WHERE Id = {id}");

            var date = new RandomDateTime();
            taxpayer.FirstName = "Karen";
            taxpayer.LastName = "Payne";
            taxpayer.Pin = "4873";
            taxpayer.SSN = "111223333";
            taxpayer.StartDate = date.Next();
            var (success, exception) = await DataOperations.UpdateWithCurrentLocalValues(taxpayer);
        }

        /// <summary>
        /// Perform no updates
        /// </summary>
        /// <returns></returns>
        private static async Task UpdateNot()
        {
            int id = 1;
            var taxpayer = await DataOperations.GetTaxpayerByIdentity(id);

            await DataOperations.OedContext.Database.ExecuteSqlRawAsync(
                "UPDATE dbo.Taxpayer SET FirstName = 'Dummy first name', LastName = 'Dummy last name' " +
                $"WHERE Id = {id}");

            var date = new RandomDateTime();
            taxpayer.FirstName = "Karen";
            taxpayer.LastName = "Payne";
            taxpayer.Pin = "4873";
            taxpayer.StartDate = date.Next();
            var (success, exception) = await DataOperations.Update(taxpayer);
        }

        private static async Task PeekChanges()
        {
            var taxpayer = await DataOperations.GetTaxpayerByIdentity(1);

            var date = new RandomDateTime();
            taxpayer.FirstName = "Karen";
            taxpayer.LastName = "Payne";
            taxpayer.Pin = "4873";
            taxpayer.StartDate = date.Next();
            taxpayer.Category = new Category() { CategoryId = 1, Description = "New" };

            var changes = await DataOperations.GetChanges(taxpayer);

            var table = CreateTaxpayerChangesViewTable();
            foreach (var item in changes)
            {
                table.AddRow(item.ItemArray);
            }

            AnsiConsole.Write(table);
        }
    }
}