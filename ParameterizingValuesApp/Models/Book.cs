using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Precision(precision: 10, scale: 2)] //introduced in EF Core 6.0.
    public decimal Price { get; set; }
    [Comment("The cat id")]
    public int CategoryId { get; set; }
    [Comment("The cat")]
    public Category Category { get; set; }
    public override string ToString() => Title;
}