# About

When working with data in EF Core, all values passed in as variables are parameterized by EF Core. This ensure that there is no chance of SQL injection in regards to injecting hacked values in place of your valuess.

## Viewng data while developing



# INSERT opterations

When adding a new record, a `Book` EF Core passes data to SQL-Server parameterized which pervents SQL Injection.


```csharp
private static async Task InsertNewBook()
{
    await using var context = new BookContext();

    decimal value = 1.4m;
    string bookTitle = "My first book";
    context.Books.Add(new Book() { Price = value, Title = bookTitle });
    Console.WriteLine(await context.SaveChangesAsync());
}
```

```
Executed DbCommand (52ms) [Parameters=[@p0='?' (Precision = 18) (Scale = 2) (DbType = Decimal), @p1='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
SET NOCOUNT ON;
INSERT INTO [Books] ([Price], [Title])
VALUES (@p0, @p1);
SELECT [Id]
FROM [Books]
WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();

```

How to get the command above, the following method is added to the `DbContext`.

```csharp
private static void DatabaseCategoryLogging(DbContextOptionsBuilder optionsBuilder)
{

    optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
         .LogTo(message => Debug.WriteLine(message),
            new[] { DbLoggerCategory.Database.Command.Name },
            LogLevel.Information,
            DbContextLoggerOptions.UtcTime);
}
```

Followed by invoking the above method in the same DbContext

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    DatabaseCategoryLogging(optionsBuilder);
}
```

To see the actual values (do this only in development, not production) which added [EnableSensitiveDataLogging](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder.enablesensitivedatalogging?view=efcore-6.0).

```csharp
private static void DatabaseCategoryLogging(DbContextOptionsBuilder optionsBuilder)
{

    optionsBuilder.UseSqlServer(ConfigurationHelper.ConnectionString())
        .EnableSensitiveDataLogging()
        .LogTo(message => Debug.WriteLine(message),
            new[] { DbLoggerCategory.Database.Command.Name },
            LogLevel.Information,
            DbContextLoggerOptions.UtcTime);
}
```

Run the INSERT again and we can see the values


```
Executed DbCommand (54ms) [Parameters=[@p0='1.4' (Precision = 18) (Scale = 2), @p1='My first book' (Size = 4000)], CommandType='Text', CommandTimeout='30']
SET NOCOUNT ON;
INSERT INTO [Books] ([Price], [Title])
VALUES (@p0, @p1);
SELECT [Id]
FROM [Books]
WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
```

Another option is to use [ChangeTracker.DebugView](https://docs.microsoft.com/en-us/ef/core/change-tracking/debug-views) as shown below.

![Long View](assets/LongView.png)

```csharp
private static async Task InsertNewBook()
{
    await using var context = new BookContext();

    decimal value = 1.4m;
    string bookTitle = "My first book";
    context.Books.Add(new Book() { Price = value, Title = bookTitle });

    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    Console.WriteLine(await context.SaveChangesAsync());
}
```

# EDIT operations

Modifying an existing record is no different than adding a new record other than we can see the original and new value but only when change tracking is enabled and the same DbContext is used, not in disconnected mode.

![Edit Book](assets/editBook.png)

```csharp
private static async Task EditExistingBook()
{
    await using var context = new BookContext();

    Book book = await context.Books.FirstOrDefaultAsync(b => b.Id == 1);

    book.Price = 19m;

    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    Console.WriteLine(await context.SaveChangesAsync());
}
```

Another option is to ask for original and new value.

![Current Original](assets/CurrentOriginal.png)