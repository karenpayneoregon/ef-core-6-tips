﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Experiment1.Models;

public partial class Shippers
{
    public int ShipperID { get; set; }

    public string CompanyName { get; set; }

    public string Phone { get; set; }

    public virtual ICollection<Orders> Orders { get; } = new List<Orders>();
}