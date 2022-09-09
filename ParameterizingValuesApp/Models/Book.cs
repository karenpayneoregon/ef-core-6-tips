using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ParameterizingValuesApp.Models;

public class Book
{
    [Key]
    [Comment("The Id")]
    public int Id { get; set; }
    [Comment("The title")]
    public string Title { get; set; }
    [Comment("The Price")]
    public decimal Price { get; set; }
    [Comment("The cat id")]
    public int CategoryId { get; set; }
    [Comment("The cat")]
    public Category Category { get; set; }
    public override string ToString() => Title;
}