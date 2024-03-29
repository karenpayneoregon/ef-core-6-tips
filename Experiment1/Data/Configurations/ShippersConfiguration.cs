﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Experiment1.Data;
using Experiment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Experiment1.Data.Configurations
{
    public partial class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> entity)
        {
            entity.HasKey(e => e.ShipperID);

            entity.Property(e => e.ShipperID).ValueGeneratedNever();
            entity.Property(e => e.CompanyName)
            .IsRequired()
            .HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Shippers> entity);
    }
}
