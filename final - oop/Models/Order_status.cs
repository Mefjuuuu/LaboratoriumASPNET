using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("order_status")]
public partial class Order_status
{
    [Key]
    public int status_id { get; set; }

    public string? status_value { get; set; }

    [InverseProperty("status")]
    public virtual ICollection<Order_history> order_histories { get; set; } = new List<Order_history>();
}
