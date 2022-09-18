using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using TaxpayerLibraryEntityVersion.Data;
using TaxpayerLibraryEntityVersion.Models;

namespace TaxpayersChanges.Classes
{
    internal class DataOperations
    {
        public static OedContext OedContext = new OedContext();
        public static async Task<Taxpayer> GetTaxpayerByIdentity(int id)
        {
            return (await OedContext.Taxpayer.FirstOrDefaultAsync(payer => payer.Id == id))!;
        }
        public static Task<List<EntityChangeItem>> GetChanges( Taxpayer taxpayer)
        {

            List<EntityChangeItem> changes = new();

            var entry = OedContext.Entry(taxpayer);

            foreach (IProperty item in entry.CurrentValues.Properties)
            {
                PropertyEntry propEntry = entry.Property(item.Name);

                if (!propEntry.IsModified) continue;

                changes.Add(new EntityChangeItem()
                {
                    PropertyName = item.Name,
                    OriginalValue = propEntry.OriginalValue,
                    CurrentValue = propEntry.CurrentValue
                });
            }

            return Task.FromResult(changes);

        }

        /// <summary>
        /// Update <see cref="Taxpayer"/> with our values even when <see cref="DbUpdateConcurrencyException"/>
        /// is thrown.
        /// </summary>
        /// <param name="taxpayer">Taxpayer to save</param>
        public static async Task<(bool, NotSupportedException)> UpdateWithCurrentLocalValues(Taxpayer taxpayer)
        {
            var saved = false;

            while (!saved)
            {
                try
                {
                    await OedContext.SaveChangesAsync();
                    saved = true;
                    return (true, null)!;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    
                    const string header = "Name                     Local value               Database value";

                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Taxpayer)
                        {
                            PropertyValues proposedValues = entry.CurrentValues;
                            PropertyValues? databaseValues = await entry.GetDatabaseValuesAsync();

                            StringBuilder builder = new();

                            builder.AppendLine("");
                            builder.AppendLine($"{nameof(DataOperations)}.{nameof(UpdateWithCurrentLocalValues)}");
                            builder.AppendLine("DbUpdateConcurrencyException");
                            builder.AppendLine(header);

                            foreach (IProperty property in proposedValues.Properties)
                            {

                                var name = property.Name;

                                var value = proposedValues[property];
                                builder.AppendLine($"{name,-24} {value,-25} {databaseValues![property]}");

                                var proposedValue = proposedValues[property];

                                proposedValues[property] = proposedValue;
                            }

                            // let's record values to file
                            SeriControl.Instance.Logger.Information(builder.ToString());

                            entry.OriginalValues.SetValues(databaseValues!);
                        }
                        else ;
                        {
                            return (false, new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for " + 
                                entry.Metadata.Name));


                        }
                    }
                }
            }

            return (false, null)!;

        }
        /// <summary>
        /// Do not update <see cref="Taxpayer"/> with local values when <see cref="DbUpdateConcurrencyException"/>
        /// is thrown.
        /// </summary>
        /// <param name="taxpayer">Taxpayer to save</param>
        public static async Task<(bool, NotSupportedException)> UpdateWithCurrentDatabaseValues(Taxpayer taxpayer)
        {
            var saved = false;

            while (!saved)
            {
                try
                {
                    await OedContext.SaveChangesAsync();
                    saved = true;
                    return (true, null)!;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is Taxpayer)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = await entry.GetDatabaseValuesAsync();

                            foreach (var property in proposedValues.Properties)
                            {
                                var name = property.Name;
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues![property];

                                // decide which value should be written to database, here we
                                // use the values sent by the caller in this case from the database
                                proposedValues[property] = databaseValue;
                            }

                            entry.OriginalValues.SetValues(databaseValues!);
                        }
                        else
                        {
                            return (false, new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for " +
                                entry.Metadata.Name));


                        }
                    }
                }
            }

            return (false, null)!;

        }

        /// <summary>
        /// Update <see cref="Taxpayer"/> with our values unless a <see cref="DbUpdateConcurrencyException"/>
        /// is thrown then abort saving the entity.
        /// </summary>
        /// <param name="taxpayer">Taxpayer to save</param>
        public static async Task<(bool, DbUpdateConcurrencyException ex)> Update(Taxpayer taxpayer)
        {
            try
            {
                await OedContext.SaveChangesAsync();
                return (true, null)!;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return (false, ex);
            }

        }


    }
}
