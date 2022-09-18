using Microsoft.EntityFrameworkCore;
using System;
using TaxpayerLibraryEntityVersion.Classes;
using TaxpayerLibraryEntityVersion.Models;
using TaxpayersChanges.Classes;

namespace TaxpayersChanges
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            
            await UpdateFavorLocal();


            Console.WriteLine("done");
            Console.ReadLine();
        }

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
            taxpayer.StartDate = date.Next();
            var (success, exception) = await DataOperations.UpdateWithCurrentLocalValues(taxpayer);
        }

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