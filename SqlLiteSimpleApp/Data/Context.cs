using Microsoft.EntityFrameworkCore;
using SqlLiteSimpleApp.Models;

namespace SqlLiteSimpleApp.Data;


public class Context : DbContext
{
    public DbSet<FileContainer> FileContainers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=files.db");
}