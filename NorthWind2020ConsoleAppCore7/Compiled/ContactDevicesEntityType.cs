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
    internal partial class ContactDevicesEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "NorthWind2020ConsoleApp.Models.ContactDevices",
                typeof(ContactDevices),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(ContactDevices).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactDevices).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            id.AddAnnotation("Relational:ColumnName", "id");
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var contactId = runtimeEntityType.AddProperty(
                "ContactId",
                typeof(int?),
                propertyInfo: typeof(ContactDevices).GetProperty("ContactId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactDevices).GetField("<ContactId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            contactId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var phoneNumber = runtimeEntityType.AddProperty(
                "PhoneNumber",
                typeof(string),
                propertyInfo: typeof(ContactDevices).GetProperty("PhoneNumber", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactDevices).GetField("<PhoneNumber>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            phoneNumber.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var phoneTypeIdentifier = runtimeEntityType.AddProperty(
                "PhoneTypeIdentifier",
                typeof(int?),
                propertyInfo: typeof(ContactDevices).GetProperty("PhoneTypeIdentifier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactDevices).GetField("<PhoneTypeIdentifier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            phoneTypeIdentifier.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { contactId });

            var index0 = runtimeEntityType.AddIndex(
                new[] { phoneTypeIdentifier });

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
                propertyInfo: typeof(ContactDevices).GetProperty("Contact", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactDevices).GetField("<Contact>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var contactDevices = principalEntityType.AddNavigation("ContactDevices",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<ContactDevices>),
                propertyInfo: typeof(Contacts).GetProperty("ContactDevices", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contacts).GetField("<ContactDevices>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_ContactDevices_Contacts1");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("PhoneTypeIdentifier")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("PhoneTypeIdenitfier")! })!,
                principalEntityType);

            var phoneTypeIdentifierNavigation = declaringEntityType.AddNavigation("PhoneTypeIdentifierNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(PhoneType),
                propertyInfo: typeof(ContactDevices).GetProperty("PhoneTypeIdentifierNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ContactDevices).GetField("<PhoneTypeIdentifierNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var contactDevices = principalEntityType.AddNavigation("ContactDevices",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<ContactDevices>),
                propertyInfo: typeof(PhoneType).GetProperty("ContactDevices", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(PhoneType).GetField("<ContactDevices>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_ContactDevices_PhoneType");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "ContactDevices");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
