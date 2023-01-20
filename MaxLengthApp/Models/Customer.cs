﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaxLengthApp.Models;

public partial class Customer
{
    [Key]
    public int Identifier { get; set; }

    [MaxLength(100)]
    public string CompanyName { get; set; }

    [StringLength(255)]
    public string ContactFirstName { get; set; }

    [StringLength(255)]
    public string ContactLastName { get; set; }

    public int? ContactTypeIdentifier { get; set; }

    public int? GenderIdentifier { get; set; }

    [ForeignKey("ContactTypeIdentifier")]
    [InverseProperty("Customer")]
    public virtual ContactTypes ContactTypeIdentifierNavigation { get; set; }

    [ForeignKey("GenderIdentifier")]
    [InverseProperty("Customer")]
    public virtual Genders GenderIdentifierNavigation { get; set; }
}