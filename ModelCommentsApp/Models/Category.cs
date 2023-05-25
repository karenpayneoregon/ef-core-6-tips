using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace ModelCommentsApp.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; set; }

    public Category()
    {
        Books = new List<Book>();
    }
}