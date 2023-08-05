using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteSimpleApp1.Models;
public class Person
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Pin { get; set; }
}
