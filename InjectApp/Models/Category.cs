using System.ComponentModel.DataAnnotations;

namespace InjectApp.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; set; }

    public override string ToString() => Description;

    public Category()
    {
        Books = new List<Book>();
    }
}