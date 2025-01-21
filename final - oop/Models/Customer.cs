using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("customer")]
public partial class Customer
{
    [Key]
    public int customer_id { get; set; }

    public string? first_name { get; set; }

    public string? last_name { get; set; }

    [EmailAddress]
    public string? email { get; set; }

    [InverseProperty("customer")]
    public virtual ICollection<Cust_order> cust_orders { get; set; } = new List<Cust_order>();

    [InverseProperty("customer")]
    public virtual ICollection<Customer_address> customer_addresses { get; set; } = new List<Customer_address>();
    
    [NotMapped]
    public int OrderCount => cust_orders.Count;

    [NotMapped]
    public string Country => customer_addresses.FirstOrDefault()?.address?.country?.country_name ?? "Unknown";

}
