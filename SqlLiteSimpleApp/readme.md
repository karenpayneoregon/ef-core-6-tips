# About

Question on a forum where a developer new to coding was having issues learning how to update a record. They tried a data provider and dapper. So I provided this for the developer to consider EF Core.

What it does

- Creates a database in the app folder
- Populates with three records
- Shows results
- Finds a record
    - Prompts for a new value
    - Saves changes
- Shows results

**Model**

```csharp
public class FileContainer
{
    public int Id { get; set; }
    public string Path1 { get; set; }
    public string Path2 { get; set; }
    public string Path3 { get; set; }
}
```

**DbContext**

```csharp
public class Context : DbContext
{
    public DbSet<FileContainer> FileContainers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=files.db");
}
```

# Create a populate

First make sure the database is deleted if exist followed by creating the database and the key in the model `Id` is made a primary key as EF Core understands having a property of type `int` with `Id` as the name or ending with `Id` should be a key unless setup in on model create or annotated on the property.

Next, add three records and save to the database.

```csharp
private static void BuildData(Context context)
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    context.FileContainers.Add(new FileContainer() { Path1 = "A1", Path2 = "A2", Path3 = "A3" });
    context.FileContainers.Add(new FileContainer() { Path1 = "B1", Path2 = "B2", Path3 = "B3" });
    context.FileContainers.Add(new FileContainer() { Path1 = "C1", Path2 = "C2", Path3 = "C3" });

    context.SaveChanges();
}
```



![F1](assets/F1.png)