using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace NorthWind2022Library.Data;

public partial class NorthWindContext
{
    /// <summary>
    /// Returns added, modified or deleted entity objects, listing their class names (not table names)
    /// and their properties, with original and current values. The key values are also included to
    /// be able to make a distinction between objects of the same type.
    /// </summary>
    /// <returns></returns>
    private IEnumerable<(string Key, string Entity, EntityState state, IEnumerable<(string Property, object OriginalValue, object CurrentValue)> Properties)> GetChanges()
    {
        var states = new[]
        {
            EntityState.Added,
            EntityState.Modified,
            EntityState.Deleted
        };

        return ChangeTracker.Entries().Where(c => states.Contains(c.State))
            .Select(entry =>
            (
                string.Join(",", entry.Metadata.FindPrimaryKey()!.Properties.Select(p => p.PropertyInfo!.GetValue(entry.Entity))),
                entry.Metadata.ClrType.Name,
                entry.State,
                entry.Properties
                    .Where(pe => pe.IsModified == (pe.EntityEntry.State == EntityState.Modified))
                    .Select(prop =>
                        (
                            prop.Metadata.PropertyInfo!.Name,
                            prop.OriginalValue,
                            prop.CurrentValue
                        )
                    )));
    }
}