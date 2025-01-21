using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("order_line")]
public partial class Order_line
{
    [Key]
    public int line_id { get; set; }

    public int? order_id { get; set; }

    public int? book_id { get; set; }

    public double? price { get; set; }

    [ForeignKey("book_id")]
    [InverseProperty("order_lines")]
    public virtual Book? book { get; set; }

    [ForeignKey("order_id")]
    [InverseProperty("order_lines")]
    public virtual Cust_order? order { get; set; }
}
