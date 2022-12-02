﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWind2020ConsoleApp.Models;

#pragma warning disable 219, 612, 618
#nullable enable

namespace NorthWind2020ConsoleAppCore7.Compiled
{
    internal partial class EmployeesEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "NorthWind2020ConsoleApp.Models.Employees",
                typeof(Employees),
                baseEntityType);

            var employeeId = runtimeEntityType.AddProperty(
                "EmployeeId",
                typeof(int),
                propertyInfo: typeof(Employees).GetProperty("EmployeeId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<EmployeeId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            employeeId.AddAnnotation("Relational:ColumnName", "EmployeeID");
            employeeId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var address = runtimeEntityType.AddProperty(
                "Address",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("Address", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<Address>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 60);
            address.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var birthDate = runtimeEntityType.AddProperty(
                "BirthDate",
                typeof(DateTime?),
                propertyInfo: typeof(Employees).GetProperty("BirthDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<BirthDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            birthDate.AddAnnotation("Relational:ColumnType", "datetime");
            birthDate.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var city = runtimeEntityType.AddProperty(
                "City",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("City", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<City>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 15);
            city.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var contactTypeIdentifier = runtimeEntityType.AddProperty(
                "ContactTypeIdentifier",
                typeof(int?),
                propertyInfo: typeof(Employees).GetProperty("ContactTypeIdentifier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<ContactTypeIdentifier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            contactTypeIdentifier.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var countryIdentifier = runtimeEntityType.AddProperty(
                "CountryIdentifier",
                typeof(int?),
                propertyInfo: typeof(Employees).GetProperty("CountryIdentifier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<CountryIdentifier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            countryIdentifier.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var extension = runtimeEntityType.AddProperty(
                "Extension",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("Extension", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<Extension>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 4);
            extension.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var firstName = runtimeEntityType.AddProperty(
                "FirstName",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("FirstName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<FirstName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 10);
            firstName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var hireDate = runtimeEntityType.AddProperty(
                "HireDate",
                typeof(DateTime?),
                propertyInfo: typeof(Employees).GetProperty("HireDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<HireDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            hireDate.AddAnnotation("Relational:ColumnType", "datetime");
            hireDate.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var homePhone = runtimeEntityType.AddProperty(
                "HomePhone",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("HomePhone", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<HomePhone>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 24);
            homePhone.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var lastName = runtimeEntityType.AddProperty(
                "LastName",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("LastName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<LastName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 20);
            lastName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var notes = runtimeEntityType.AddProperty(
                "Notes",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("Notes", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<Notes>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            notes.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var postalCode = runtimeEntityType.AddProperty(
                "PostalCode",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("PostalCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<PostalCode>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 10);
            postalCode.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var region = runtimeEntityType.AddProperty(
                "Region",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("Region", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<Region>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 15);
            region.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var reportsTo = runtimeEntityType.AddProperty(
                "ReportsTo",
                typeof(int?),
                propertyInfo: typeof(Employees).GetProperty("ReportsTo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<ReportsTo>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            reportsTo.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var titleOfCourtesy = runtimeEntityType.AddProperty(
                "TitleOfCourtesy",
                typeof(string),
                propertyInfo: typeof(Employees).GetProperty("TitleOfCourtesy", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<TitleOfCourtesy>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 25);
            titleOfCourtesy.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { employeeId });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { contactTypeIdentifier });

            var index0 = runtimeEntityType.AddIndex(
                new[] { countryIdentifier });

            var index1 = runtimeEntityType.AddIndex(
                new[] { reportsTo });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ContactTypeIdentifier")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("ContactTypeIdentifier")! })!,
                principalEntityType);

            var contactTypeIdentifierNavigation = declaringEntityType.AddNavigation("ContactTypeIdentifierNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(ContactType),
                propertyInfo: typeof(Employees).GetProperty("ContactTypeIdentifierNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<ContactTypeIdentifierNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var employees = principalEntityType.AddNavigation("Employees",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Employees>),
                propertyInfo: typeof(ContactType).GetProperty("Employees", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactType).GetField("<Employees>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Employees_ContactType");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CountryIdentifier")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("CountryIdentifier")! })!,
                principalEntityType);

            var countryIdentifierNavigation = declaringEntityType.AddNavigation("CountryIdentifierNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Countries),
                propertyInfo: typeof(Employees).GetProperty("CountryIdentifierNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<CountryIdentifierNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var employees = principalEntityType.AddNavigation("Employees",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Employees>),
                propertyInfo: typeof(Countries).GetProperty("Employees", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Countries).GetField("<Employees>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Employees_Countries");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey3(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ReportsTo")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("EmployeeId")! })!,
                principalEntityType);

            var reportsToNavigation = declaringEntityType.AddNavigation("ReportsToNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Employees),
                propertyInfo: typeof(Employees).GetProperty("ReportsToNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<ReportsToNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var workersNavigation = principalEntityType.AddNavigation("WorkersNavigation",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Employees>),
                propertyInfo: typeof(Employees).GetProperty("WorkersNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Employees).GetField("<WorkersNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Employees_Employees");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Employees");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}