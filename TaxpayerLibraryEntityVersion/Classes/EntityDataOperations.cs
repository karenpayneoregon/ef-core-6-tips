using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaxpayerLibraryEntityVersion.Data;
using TaxpayerLibraryEntityVersion.Models;

namespace TaxpayerLibraryEntityVersion.Classes
{
    public class EntityDataOperations
    {
        public static async Task<List<Taxpayer>> GetTaxpayers()
        {
            await using var context = new OedContext();
            return await context.Taxpayer.ToListAsync();
        }

        public static async Task<Taxpayer> GetTaxpayerByIdentity(int id)
        {
            await using var context = new OedContext();
            return (await context.Taxpayer.FirstOrDefaultAsync(payer => payer.Id == id))!;
        }

        /// <summary>
        /// A demonstration which shows how to look at, in this case a Taxpayer property values
        /// after one or more changes have been made and get the changes using a generic method.
        ///
        /// Why do this? To show we can examine original and current values
        /// </summary>
        public static async Task<List<EntityChangeItem>> GetOriginalValuesAfterEditingVersion1()
        {
            await using var context = new OedContext();

            int id = 1;
            Taxpayer taxpayer = (await context.Taxpayer.FirstOrDefaultAsync(payer => payer.Id == id))!;

            taxpayer.FirstName = "Karen";
            taxpayer.Pin = "9999";

            List<EntityChangeItem> changes = new();

            var entry = context.Entry(taxpayer);

            foreach (IProperty property in entry.CurrentValues.Properties)
            {
                var propertyEntry = entry.Property(property.Name);

                if (!propertyEntry.IsModified) continue;

                changes.Add(new EntityChangeItem()
                {
                    PropertyName = property.Name, 
                    OriginalValue = propertyEntry.OriginalValue, 
                    CurrentValue = propertyEntry.CurrentValue
                });
            }

            return changes;

        }
        /// <summary>
        /// A demonstration which shows how to look at, in this case a Taxpayer property values
        /// after one or more changes have been made and get the changes which targets <see cref="Taxpayer"/>
        ///
        /// Why do this? To show we can examine original and current values
        /// </summary>
        public static async Task GetOriginalValuesAfterEditingVersion2()
        {
            await using var context = new OedContext();

            Taxpayer taxpayer = (await context.Taxpayer.FirstOrDefaultAsync(payer => payer.Id == 1))!;

            taxpayer.FirstName = "Karen";


            var originalFirstName = context
                .Entry(taxpayer)
                .Property(x => x.FirstName)
                .OriginalValue;

            // note use of nameof
            var currentFirstName = context
                .Entry(taxpayer)
                .Property(nameof(taxpayer.FirstName))
                .CurrentValue;

        }

        /// <summary>
        /// Add a new <see cref="Taxpayer"/>
        /// </summary>
        /// <param name="taxpayer"></param>
        /// <returns></returns>
        public static async Task AddNewTaxpayer(Taxpayer taxpayer)
        {
            await using var context = new OedContext();
            context.Add(taxpayer);
            await context.SaveChangesAsync();
        }

        public static async Task<(Taxpayer taxpayer, bool)> EditTaxpayer()
        {
            await using var context = new OedContext();
            int id = 3;
            Taxpayer taxpayer = context.Taxpayer.FirstOrDefault(x => x.Id == id)!;
            if (taxpayer is not null)
            {
                RandomDateTime date = new();
                taxpayer.StartDate = date.Next();
                await context.SaveChangesAsync();
                return (taxpayer, true);
            }
            else
            {
                return (null, false)!;
            }
        }
    }
}
