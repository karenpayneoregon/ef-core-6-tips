# Various tips for working with Entity Framework Core 6

![1Unicorn](assets/1unicorn.png)

Although this article targets EF Core 6 there will be some examples mentioned from EF Core 5 which do not work in EF Core 6 and have been rewritten to work with EF Core.

Also, there are several code samples taken from Microsoft and are marked so in their readme files.

Hopefully what is provided will assist all levels of developers.

# Projects

Projects in this solution

| Project        |   Description    |   Notes |
|:------------- |:-------------|:-------------|
| EntityCore5Extensions |  |  |
| EntityFrameworkCoreHelpers |  |  |
| ExtensionsLibrary |  |  |
| ColumnOrderFromMicrosoftApp |  | This code is from Microsoft with minor changes by Karen Payne |
| LoggingOptionsApp |  |  |
| ModelCommentsApp |  |  |
| ModelCommentsApp1 |  | Migrations |
| ParameterizingValuesApp |  |  |
| NorthWind2020ConsoleApp | An example of a self-referencing table for managers and workers | Originally .NET Core 5, EF Core 5 and was updated to .NET Core 6, EF Core 6. |
| ValueConversionsEncryptProperty | An example for encrypting string via EF Core HasConversion | Based off a Microsoft sample |
| NorthWindContactsApp | Example on using EF Core in a Windows Forms project | Based off a Microsoft sample |
|  |  |  |

# Requires

- Microsoft Visual Studio 2022 or higher
- SSMS (SQL-Server Management Studio) is optional but will make life easier

# How to reverse engineer a database

See the following [page](ReverseEngineer.md) to learn how to reverse engineer a new SQL-Server database using EF Power Tools, step by step.

# Resources

- Entity Framework Core docs [![](assets/Link_16x.png)](https://docs.microsoft.com/en-us/ef/core/)
- Querying Data [![](assets/Link_16x.png)](https://docs.microsoft.com/en-us/ef/core/querying/)
- Saving Data [![](assets/Link_16x.png)](https://docs.microsoft.com/en-us/ef/core/saving/)
- Database Providers [![](assets/Link_16x.png)](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)
- EF Core Value Conversions [![](assets/Link_16x.png)](https://github.com/karenpayneoregon/ef-core-transforming)
- EF Core: Working with TimeOnly [![](assets/Link_16x.png)](https://github.com/karenpayneoregon/ef-core-dateonly-timeonly)
- Using EF Core and Bogus [![](assets/Link_16x.png)](https://github.com/karenpayneoregon/learn-bogus-efcore)
- Port from EF6 to EF Core [![](assets/Link_16x.png)](https://docs.microsoft.com/en-us/ef/efcore-and-ef6/porting/)