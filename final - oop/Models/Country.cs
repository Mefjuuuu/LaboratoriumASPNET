using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("country")]
public partial class Country
{
    [Key]
    public int country_id { get; set; }

    public string? country_name { get; set; }

    [InverseProperty("country")]
    public virtual ICollection<Address> addresses { get; set; } = new List<Address>();
}
