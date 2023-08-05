﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MaxLengthApp.Models;

public partial class ContactTypes
{
    [Key]
    public int Identifier { get; set; }

    [StringLength(50)]
    public string ContactType { get; set; }

    [InverseProperty("ContactTypeIdentifierNavigation")]
    public virtual ICollection<Customer> Customer { get; } = new List<Customer>();
}