using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TaxpayerLibraryEntityVersion.Models;

public partial class Taxpayer
{
    public int Id { get; set; }
    [ConcurrencyCheck]
    public string FirstName { get; set; }
    [ConcurrencyCheck]
    public string LastName { get; set; }

    // ignore when serializing
    [JsonIgnore]
    public string FullName => $"{FirstName} {LastName}";

    public string SSN { get; set; }

    // ignore when serializing
    [JsonIgnore]
    public string SocialSecurityNumber => 
        SSN.Insert(5, "-").Insert(3, "-");

    public string Pin { get; set; }
    public DateTime? StartDate { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }


    public override string ToString() => $"{FirstName} {LastName}";
}