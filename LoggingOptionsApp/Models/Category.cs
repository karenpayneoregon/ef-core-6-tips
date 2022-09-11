using System.ComponentModel.DataAnnotations;

namespace LoggingOptionsApp.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Description { get; set; }

}