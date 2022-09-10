﻿using System.ComponentModel.DataAnnotations;

namespace ModelCommentsApp1.Models;

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