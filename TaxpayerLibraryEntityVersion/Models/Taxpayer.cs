using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using TaxpayerLibraryEntityVersion.Classes;

namespace TaxpayerLibraryEntityVersion.Models;

public partial class Taxpayer : IHasTimestamps, ISoftDelete, INotifyPropertyChanged
{
    private bool? _deleted;
    public int Id { get; set; }
    [ConcurrencyCheck]
    public string FirstName { get; set; }

    [ConcurrencyCheck]
    public string LastName { get; set; }

    [JsonIgnore]
    public string FullName => $"{FirstName} {LastName}";
    [ConcurrencyCheck]
    public string SSN { get; set; }
    
    [JsonIgnore]
    public string SocialSecurityNumber =>
        SSN.Insert(5, "-").Insert(3, "-");

    [ConcurrencyCheck]
    public string Pin { get; set; }

    [ConcurrencyCheck]
    public DateTime? StartDate { get; set; }

    [ConcurrencyCheck]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    #region Used in override of SaveChanges
    public DateTime? Added { get; set; }
    public DateTime? DeletedOn { get; set; }
    public DateTime? Modified { get; set; } 
    #endregion

    #region Soft delete 
    [NotMapped]
    public bool IsDeleted
    {
        get => Deleted != null && (bool)Deleted;
        set => Deleted = value;
    }
    public bool? Deleted
    {
        get => _deleted;
        set
        {
            _deleted = value;
            OnPropertyChanged();
        }
    } 
    #endregion

    public override string ToString() => $"{FirstName} {LastName}";

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}