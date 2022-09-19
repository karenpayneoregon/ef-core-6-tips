using DbContextPooling.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextPooling.Data;

public class BloggingContext : DbContext
{
    public static long InstanceCount;

    public BloggingContext(DbContextOptions options) : base(options)
    {
        Interlocked.Increment(ref InstanceCount);
    }

    public DbSet<Blog> Blogs { get; set; }
}