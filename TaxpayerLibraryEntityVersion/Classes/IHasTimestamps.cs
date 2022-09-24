namespace TaxpayerLibraryEntityVersion.Classes;

/// <summary>
/// For recording when a record is soft deleted, changed or new record added
/// </summary>
public interface IHasTimestamps
{
    /// <summary>
    /// New record added
    /// </summary>
    DateTime? Added { get; set; }
    /// <summary>
    /// Record marked as deleted
    /// </summary>
    DateTime? DeletedOn { get; set; }
    /// <summary>
    /// Record modified
    /// </summary>
    DateTime? Modified { get; set; }
}