using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("order_history")]
public partial class Order_history
{
    [Key]
    public int history_id { get; set; }

    public int? order_id { get; set; }

    public int? status_id { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? status_date { get; set; }

    [ForeignKey("order_id")]
    [InverseProperty("order_histories")]
    public virtual Cust_order? order { get; set; }

    [ForeignKey("status_id")]
    [InverseProperty("order_histories")]
    public virtual Order_status? status { get; set; }
}
