using Microsoft.EntityFrameworkCore;

namespace DbContextPooling.Classes;

public class BloggingContext : DbContext
{
    public static long InstanceCount;

    public BloggingContext(DbContextOptions options) : base(options)
    {
        Interlocked.Increment(ref InstanceCount);
    }

    public DbSet<Blog> Blogs { get; set; }
}