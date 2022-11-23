# About


EF Core code samples using a modified version of NorthWind database, script to create and populate is located in the script folder.

:heavy_check_mark: Converted to a benchmark to see difference between EF Core 6 and EF Core 7

- `EmployeeOperations.EmployeeReportsTo` is an example of a self-referencing table for managers and workers.

This is the configuration in EmployeeConfiguration.cs to have a self-referencing table

```csharp
entity.HasOne(d => d.ReportsToNavigation)
    .WithMany(p => p.WorkersNavigation)
    .HasForeignKey(d => d.ReportsTo)
    .HasConstraintName("FK_Employees_Employees");
```

</br>

![Keys](assets/keys.png)


</br>


![Screenshot](assets/screenshot.png)

