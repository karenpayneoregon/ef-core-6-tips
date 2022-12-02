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
    internal partial class ProductsEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "NorthWind2020ConsoleApp.Models.Products",
                typeof(Products),
                baseEntityType);

            var productId = runtimeEntityType.AddProperty(
                "ProductId",
                typeof(int),
                propertyInfo: typeof(Products).GetProperty("ProductId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<ProductId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            productId.AddAnnotation("Relational:ColumnName", "ProductID");
            productId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var categoryId = runtimeEntityType.AddProperty(
                "CategoryId",
                typeof(int?),
                propertyInfo: typeof(Products).GetProperty("CategoryId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<CategoryId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            categoryId.AddAnnotation("Relational:ColumnName", "CategoryID");
            categoryId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var discontinued = runtimeEntityType.AddProperty(
                "Discontinued",
                typeof(bool),
                propertyInfo: typeof(Products).GetProperty("Discontinued", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<Discontinued>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            discontinued.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var discontinuedDate = runtimeEntityType.AddProperty(
                "DiscontinuedDate",
                typeof(DateTime?),
                propertyInfo: typeof(Products).GetProperty("DiscontinuedDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<DiscontinuedDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            discontinuedDate.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var productName = runtimeEntityType.AddProperty(
                "ProductName",
                typeof(string),
                propertyInfo: typeof(Products).GetProperty("ProductName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<ProductName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 40);
            productName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var quantityPerUnit = runtimeEntityType.AddProperty(
                "QuantityPerUnit",
                typeof(string),
                propertyInfo: typeof(Products).GetProperty("QuantityPerUnit", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<QuantityPerUnit>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 20);
            quantityPerUnit.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var reorderLevel = runtimeEntityType.AddProperty(
                "ReorderLevel",
                typeof(short?),
                propertyInfo: typeof(Products).GetProperty("ReorderLevel", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<ReorderLevel>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            reorderLevel.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var supplierId = runtimeEntityType.AddProperty(
                "SupplierId",
                typeof(int?),
                propertyInfo: typeof(Products).GetProperty("SupplierId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<SupplierId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            supplierId.AddAnnotation("Relational:ColumnName", "SupplierID");
            supplierId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var unitPrice = runtimeEntityType.AddProperty(
                "UnitPrice",
                typeof(decimal?),
                propertyInfo: typeof(Products).GetProperty("UnitPrice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<UnitPrice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            unitPrice.AddAnnotation("Relational:ColumnType", "money");
            unitPrice.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var unitsInStock = runtimeEntityType.AddProperty(
                "UnitsInStock",
                typeof(short?),
                propertyInfo: typeof(Products).GetProperty("UnitsInStock", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<UnitsInStock>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            unitsInStock.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var unitsOnOrder = runtimeEntityType.AddProperty(
                "UnitsOnOrder",
                typeof(short?),
                propertyInfo: typeof(Products).GetProperty("UnitsOnOrder", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<UnitsOnOrder>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            unitsOnOrder.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { productId });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { categoryId });

            var index0 = runtimeEntityType.AddIndex(
                new[] { supplierId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CategoryId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("CategoryId")! })!,
                principalEntityType);

            var category = declaringEntityType.AddNavigation("Category",
                runtimeForeignKey,
                onDependent: true,
                typeof(Categories),
                propertyInfo: typeof(Products).GetProperty("Category", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<Category>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Products>),
                propertyInfo: typeof(Categories).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Categories).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Products_Categories");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("SupplierId")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("SupplierId")! })!,
                principalEntityType);

            var supplier = declaringEntityType.AddNavigation("Supplier",
                runtimeForeignKey,
                onDependent: true,
                typeof(Suppliers),
                propertyInfo: typeof(Products).GetProperty("Supplier", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Products).GetField("<Supplier>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Products>),
                propertyInfo: typeof(Suppliers).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Suppliers).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "FK_Products_Suppliers");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Products");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}