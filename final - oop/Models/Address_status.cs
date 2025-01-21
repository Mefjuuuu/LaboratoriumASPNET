using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("address_status")]
public partial class Address_status
{
    [Key]
    public int status_id { get; set; }

    [Column("address_status")]
    public string? address_status1 { get; set; }
}
