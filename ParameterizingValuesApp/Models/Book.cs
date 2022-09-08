using System.ComponentModel.DataAnnotations;

namespace ParameterizingValuesApp.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public override string ToString() => Title;
}