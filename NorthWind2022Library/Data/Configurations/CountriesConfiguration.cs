﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind2022Library.Data;
using NorthWind2022Library.Models;
using System;
using System.Collections.Generic;

namespace NorthWind2022Library.Data.Configurations
{
    public partial class CountriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> entity)
        {
            entity.HasKey(e => e.CountryIdentifier);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Countries> entity);
    }
}
