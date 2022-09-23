using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelectiveUpdatesApp.Models;

namespace SelectiveUpdatesApp.Data.Configurations;

public partial class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> entity)
    {
        entity.Property(e => e.BirthDate)
            .HasColumnType("date")
            .HasComment("Their birth date");

        entity.Property(e => e.FirstName)
            .HasComment("First name");

        entity.Property(e => e.LastName)
            .HasComment("last name");

        entity.Property(e => e.Title)
            .HasComment("Mr Miss Mrs");

        entity.Property(e => e.Id)
            .HasComment("Primary key");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Person> entity);
}