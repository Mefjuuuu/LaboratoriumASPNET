using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("shipping_method")]
public partial class Shipping_method
{
    [Key]
    public int method_id { get; set; }

    public string? method_name { get; set; }

    public double? cost { get; set; }

    [InverseProperty("shipping_method")]
    public virtual ICollection<Cust_order> cust_orders { get; set; } = new List<Cust_order>();
}
