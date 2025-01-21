using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("book")]
public partial class Book
{
    [Key]
    public int book_id { get; set; }

    public string? title { get; set; }

    public string? isbn13 { get; set; }

    public int? language_id { get; set; }

    public int? num_pages { get; set; }

    [Column(TypeName = "DATE")]
    public DateOnly? publication_date { get; set; }

    public int? publisher_id { get; set; }

    [ForeignKey("language_id")]
    [InverseProperty("books")]
    public virtual Book_language? language { get; set; }

    [InverseProperty("book")]
    public virtual ICollection<Order_line> order_lines { get; set; } = new List<Order_line>();

    [ForeignKey("publisher_id")]
    [InverseProperty("books")]
    public virtual Publisher? publisher { get; set; }

    [ForeignKey("book_id")]
    [InverseProperty("books")]
    public virtual ICollection<Author> authors { get; set; } = new List<Author>();
}
