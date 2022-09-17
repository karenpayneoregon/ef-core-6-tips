
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TaxpayerLibraryEntityVersion.Models;

/// <summary>
/// Container for use with looking at a <see cref="PropertyEntry{TEntity,TProperty}"/> which has a state of modified
/// </summary>
public class EntityChangeItem
{
    /// <summary>
    /// Property name to get values for
    /// </summary>
    public  string PropertyName { get; set; }
    /// <summary>
    /// Original value for <see cref="PropertyName"/>
    /// </summary>
    public object OriginalValue { get; set; }
    /// <summary>
    /// Current value for <see cref="PropertyName"/>
    /// </summary>
    public  object CurrentValue { get; set; }

    public string[] ItemArray => new[]
    {
        PropertyName,
        OriginalValue.ToString(),
        CurrentValue.ToString()
    };

    public override string ToString() => $"{PropertyName} | {OriginalValue} | {CurrentValue}";

}