﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TaxpayerLibraryEntityVersion.Models;

public partial class Taxpayer
{
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


    public override string ToString() => $"{FirstName} {LastName}";
}