using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("book_language")]
public partial class Book_language
{
    [Key]
    public int language_id { get; set; }

    public string? language_code { get; set; }

    public string? language_name { get; set; }

    [InverseProperty("language")]
    public virtual ICollection<Book> books { get; set; } = new List<Book>();
}
