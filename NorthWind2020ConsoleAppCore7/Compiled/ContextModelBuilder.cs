﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace NorthWind2020ConsoleAppCore7.Compiled
{
    public partial class ContextModel
    {
        partial void Initialize()
        {
            var businessEntityPhone = BusinessEntityPhoneEntityType.Create(this);
            var categories = CategoriesEntityType.Create(this);
            var contactDevices = ContactDevicesEntityType.Create(this);
            var contactType = ContactTypeEntityType.Create(this);
            var contacts = ContactsEntityType.Create(this);
            var countries = CountriesEntityType.Create(this);
            var customers = CustomersEntityType.Create(this);
            var employeeTerritories = EmployeeTerritoriesEntityType.Create(this);
            var employees = EmployeesEntityType.Create(this);
            var orderDetails = OrderDetailsEntityType.Create(this);
            var orders = OrdersEntityType.Create(this);
            var phoneType = PhoneTypeEntityType.Create(this);
            var products = ProductsEntityType.Create(this);
            var region = RegionEntityType.Create(this);
            var shippers = ShippersEntityType.Create(this);
            var suppliers = SuppliersEntityType.Create(this);
            var territories = TerritoriesEntityType.Create(this);

            ContactDevicesEntityType.CreateForeignKey1(contactDevices, contacts);
            ContactDevicesEntityType.CreateForeignKey2(contactDevices, phoneType);
            ContactsEntityType.CreateForeignKey1(contacts, contactType);
            CustomersEntityType.CreateForeignKey1(customers, contacts);
            CustomersEntityType.CreateForeignKey2(customers, contactType);
            CustomersEntityType.CreateForeignKey3(customers, countries);
            EmployeeTerritoriesEntityType.CreateForeignKey1(employeeTerritories, employees);
            EmployeeTerritoriesEntityType.CreateForeignKey2(employeeTerritories, territories);
            EmployeesEntityType.CreateForeignKey1(employees, contactType);
            EmployeesEntityType.CreateForeignKey2(employees, countries);
            EmployeesEntityType.CreateForeignKey3(employees, employees);
            OrderDetailsEntityType.CreateForeignKey1(orderDetails, orders);
            OrderDetailsEntityType.CreateForeignKey2(orderDetails, products);
            OrdersEntityType.CreateForeignKey1(orders, customers);
            OrdersEntityType.CreateForeignKey2(orders, employees);
            OrdersEntityType.CreateForeignKey3(orders, shippers);
            ProductsEntityType.CreateForeignKey1(products, categories);
            ProductsEntityType.CreateForeignKey2(products, suppliers);
            SuppliersEntityType.CreateForeignKey1(suppliers, countries);
            TerritoriesEntityType.CreateForeignKey1(territories, region);

            BusinessEntityPhoneEntityType.CreateAnnotations(businessEntityPhone);
            CategoriesEntityType.CreateAnnotations(categories);
            ContactDevicesEntityType.CreateAnnotations(contactDevices);
            ContactTypeEntityType.CreateAnnotations(contactType);
            ContactsEntityType.CreateAnnotations(contacts);
            CountriesEntityType.CreateAnnotations(countries);
            CustomersEntityType.CreateAnnotations(customers);
            EmployeeTerritoriesEntityType.CreateAnnotations(employeeTerritories);
            EmployeesEntityType.CreateAnnotations(employees);
            OrderDetailsEntityType.CreateAnnotations(orderDetails);
            OrdersEntityType.CreateAnnotations(orders);
            PhoneTypeEntityType.CreateAnnotations(phoneType);
            ProductsEntityType.CreateAnnotations(products);
            RegionEntityType.CreateAnnotations(region);
            ShippersEntityType.CreateAnnotations(shippers);
            SuppliersEntityType.CreateAnnotations(suppliers);
            TerritoriesEntityType.CreateAnnotations(territories);

            AddAnnotation("ProductVersion", "7.0.0");
            AddAnnotation("Relational:MaxIdentifierLength", 128);
            AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
