﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Experiment1.Data;
using Experiment1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Experiment1.Data.Configurations
{
    public partial class SupplierRegionConfiguration : IEntityTypeConfiguration<SupplierRegion>
    {
        public void Configure(EntityTypeBuilder<SupplierRegion> entity)
        {
            entity.HasKey(e => e.RegionId);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<SupplierRegion> entity);
    }
}
