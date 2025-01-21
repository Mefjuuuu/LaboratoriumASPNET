using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[PrimaryKey("customer_id", "address_id")]
[Table("customer_address")]
public partial class Customer_address
{
    [Key]
    public int customer_id { get; set; }

    [Key]
    public int address_id { get; set; }

    public int? status_id { get; set; }

    [ForeignKey("address_id")]
    [InverseProperty("customer_addresses")]
    public virtual Address address { get; set; } = null!;

    [ForeignKey("customer_id")]
    [InverseProperty("customer_addresses")]
    public virtual Customer customer { get; set; } = null!;
    
}
