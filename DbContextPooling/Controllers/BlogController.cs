using DbContextPooling.Data;
using DbContextPooling.Models;
using Microsoft.EntityFrameworkCore;

namespace DbContextPooling.Controllers;

public class BlogController
{
    private readonly BloggingContext _context;

    public BlogController(BloggingContext context)
    {
        _context = context;
    }

    public async Task<Blog> GetBlogAsync()
    {
        Refresh();
        return await _context.Blogs.FirstAsync();
    }
    public void Refresh()
    {
        _context.Database.CloseConnection();
        _context.Database.OpenConnection();
    }
}