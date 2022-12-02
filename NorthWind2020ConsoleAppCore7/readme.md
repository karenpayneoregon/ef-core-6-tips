# About

- **Benchmarking** against project `NorthWind2020ConsoleApp` which is .NET Core 6, EF Core 6 while this project is .NET Core 7, EF Core 7.
- **Compiled Models** When you have a large model and your EF Core startup is slow.

# Compiled Models

Compiled models can improve EF Core startup time for applications with large models. Startup time means the time to perform the first operation on a DbContext when that DbContext type is used for the first time in the application.

## Limitations

From [Microsoft docs](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew#limitations)

- Global query filters are not supported.
- Lazy loading and change-tracking proxies are not supported.
- Custom IModelCacheKeyFactory implementations are not supported. However, you can compile multiple models and load the appropriate one as needed.
- The model must be manually synchronized by regenerating it any time the model definition or configuration change.

Because of these limitations, you should only use compiled models if your EF Core startup time is too slow. Compiling small models is typically not worth it.

**CLI**

- Make sure dotnet tool is up todate.
- Install package `Microsoft.EntityFrameworkCore.Design`
- Recommend specifying the folder for the compiled models using `--output-dir`
- Run this when the a model changes

```
dotnet ef dbcontext optimize --output-dir Compiled
```

**DbContext**

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{

    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder
            .UseModel(ContextModel.Instance)
            .UseSqlServer(ConfigurationHelper.ConnectionString())
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
```
