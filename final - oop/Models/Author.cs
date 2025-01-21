using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("author")]
public partial class Author
{
    [Key]
    public int author_id { get; set; }

    public string? author_name { get; set; }

    [ForeignKey("author_id")]
    [InverseProperty("authors")]
    public virtual ICollection<Book> books { get; set; } = new List<Book>();
}
