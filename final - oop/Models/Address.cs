using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("address")]
public partial class Address
{
    [Key]
    public int address_id { get; set; }

    public string? street_number { get; set; }

    public string? street_name { get; set; }

    public string? city { get; set; }

    public int? country_id { get; set; }

    [ForeignKey("country_id")]
    [InverseProperty("addresses")]
    public virtual Country? country { get; set; }

    [InverseProperty("dest_address")]
    public virtual ICollection<Cust_order> cust_orders { get; set; } = new List<Cust_order>();

    [InverseProperty("address")]
    public virtual ICollection<Customer_address> customer_addresses { get; set; } = new List<Customer_address>();
}
