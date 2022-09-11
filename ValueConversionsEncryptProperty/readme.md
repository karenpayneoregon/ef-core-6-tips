# About

[Microsoft source](https://github.com/dotnet/EntityFramework.Docs/blob/main/samples/core/Modeling/ValueConversions/EncryptPropertyValues.cs)

Simple starter code sample for `HasConversion` which in this case takes a string and reverses the string and stores in the table then read back reverses the value back to what was entered.

**Original conversion**

Which is great as it allows a developer to work from a simple example to implement their own logic

```csharp
modelBuilder.Entity<User>().Property(e => e.Password).HasConversion(
    v => new string(v.Reverse().ToArray()),
    v => new string(v.Reverse().ToArray()));
```

**Current conversion**

Sample to go passed the above.

```csharp
modelBuilder.Entity<User>().Property(e => e.Password).HasConversion(
    v => EncryptString(v),
    v => DecryptString(v));
```