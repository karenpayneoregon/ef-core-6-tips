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
    internal partial class CustomersEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "NorthWind2020ConsoleApp.Models.Customers",
                typeof(Customers),
                baseEntityType);

            var customerIdentifier = runtimeEntityType.AddProperty(
                "CustomerIdentifier",
                typeof(int),
                propertyInfo: typeof(Customers).GetProperty("CustomerIdentifier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<CustomerIdentifier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            customerIdentifier.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var city = runtimeEntityType.AddProperty(
                "City",
                typeof(string),
                propertyInfo: typeof(Customers).GetProperty("City", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<City>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 15);
            city.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var companyName = runtimeEntityType.AddProperty(
                "CompanyName",
                typeof(string),
                propertyInfo: typeof(Customers).GetProperty("CompanyName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<CompanyName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 40);
            companyName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var contactId = runtimeEntityType.AddProperty(
                "ContactId",
                typeof(int?),
                propertyInfo: typeof(Customers).GetProperty("ContactId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<ContactId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            contactId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var contactTypeIdentifier = runtimeEntityType.AddProperty(
                "ContactTypeIdentifier",
                typeof(int?),
                propertyInfo: typeof(Customers).GetProperty("ContactTypeIdentifier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<ContactTypeIdentifier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            contactTypeIdentifier.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var countryIdentifier = runtimeEntityType.AddProperty(
                "CountryIdentifier",
                typeof(int?),
                propertyInfo: typeof(Customers).GetProperty("CountryIdentifier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<CountryIdentifier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            countryIdentifier.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var fax = runtimeEntityType.AddProperty(
                "Fax",
                typeof(string),
                propertyInfo: typeof(Customers).GetProperty("Fax", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<Fax>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 24);
            fax.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var modifiedDate = runtimeEntityType.AddProperty(
                "ModifiedDate",
                typeof(DateTime?),
                propertyInfo: typeof(Customers).GetProperty("ModifiedDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<ModifiedDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueGenerated: ValueGenerated.OnAdd);
            modifiedDate.AddAnnotation("Relational:DefaultValueSql", "(getdate())");
            modifiedDate.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var phone = runtimeEntityType.AddProperty(
                "Phone",
                typeof(string),
                propertyInfo: typeof(Customers).GetProperty("Phone", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<Phone>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 24);
            phone.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var postalCode = runtimeEntityType.AddProperty(
                "PostalCode",
                typeof(string),
                propertyInfo: typeof(Customers).GetProperty("PostalCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<PostalCode>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 10);
            postalCode.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var region = runtimeEntityType.AddProperty(
                "Region",
                typeof(string),
                propertyInfo: typeof(Customers).GetProperty("Region", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<Region>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 15);
            region.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var street = runtimeEntityType.AddProperty(
                "Street",
                typeof(string),
                propertyInfo: typeof(Customers).GetProperty("Street", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<Street>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 60);
            street.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { customerIdentifier });
            runtimeEntityType.SetPrimaryKey(key);
            key.AddAnnotation("Relational:Name", "PK_Customers_1");

            var index = runtimeEntityType.AddIndex(
                new[] { contactId });

            var index0 = runtimeEntityType.AddIndex(
                new[] { contactTypeIdentifier });

            var index1 = runtimeEntityType.AddIndex(
                new[] { countryIdentifier });

            var city0 = runtimeEntityType.AddIndex(
                new[] { city },
                name: "City");

            var companyName0 = runtimeEntityType.AddIndex(
                new[] { companyName },
                name: "CompanyName");

            var postalCode0 = runtimeEntityType.AddIndex(
                new[] { postalCode },
                name: "PostalCode");

            var region0 = runtimeEntityType.AddIndex(
                new[] { region },
                name: "Region");

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ContactId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("ContactId")! })!,
                principalEntityType);

            var contact = declaringEntityType.AddNavigation("Contact",
                runtimeForeignKey,
                onDependent: true,
                typeof(Contacts),
                propertyInfo: typeof(Customers).GetProperty("Contact", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<Contact>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var customers = principalEntityType.AddNavigation("Customers",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Customers>),
                propertyInfo: typeof(Contacts).GetProperty("Customers", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contacts).GetField("<Customers>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Customers_Contacts");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ContactTypeIdentifier")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("ContactTypeIdentifier")! })!,
                principalEntityType);

            var contactTypeIdentifierNavigation = declaringEntityType.AddNavigation("ContactTypeIdentifierNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(ContactType),
                propertyInfo: typeof(Customers).GetProperty("ContactTypeIdentifierNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<ContactTypeIdentifierNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var customers = principalEntityType.AddNavigation("Customers",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Customers>),
                propertyInfo: typeof(ContactType).GetProperty("Customers", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactType).GetField("<Customers>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Customers_ContactType");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey3(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CountryIdentifier")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("CountryIdentifier")! })!,
                principalEntityType);

            var countryIdentifierNavigation = declaringEntityType.AddNavigation("CountryIdentifierNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Countries),
                propertyInfo: typeof(Customers).GetProperty("CountryIdentifierNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Customers).GetField("<CountryIdentifierNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var customers = principalEntityType.AddNavigation("Customers",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Customers>),
                propertyInfo: typeof(Countries).GetProperty("Customers", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Countries).GetField("<Customers>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Customers_Countries");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Customers");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
