using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("publisher")]
public partial class Publisher
{
    [Key]
    public int publisher_id { get; set; }

    public string? publisher_name { get; set; }

    [InverseProperty("publisher")]
    public virtual ICollection<Book> books { get; set; } = new List<Book>();
}
