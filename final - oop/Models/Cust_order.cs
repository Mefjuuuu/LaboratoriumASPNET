using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

[Table("cust_order")]
public partial class Cust_order
{
    [Key]
    public int order_id { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? order_date { get; set; }

    public int? customer_id { get; set; }

    public int? shipping_method_id { get; set; }

    public int? dest_address_id { get; set; }

    [ForeignKey("customer_id")]
    [InverseProperty("cust_orders")]
    public virtual Customer? customer { get; set; }

    [ForeignKey("dest_address_id")]
    [InverseProperty("cust_orders")]
    public virtual Address? dest_address { get; set; }

    [InverseProperty("order")]
    public virtual ICollection<Order_history> order_histories { get; set; } = new List<Order_history>();

    [InverseProperty("order")]
    public virtual ICollection<Order_line> order_lines { get; set; } = new List<Order_line>();

    [ForeignKey("shipping_method_id")]
    [InverseProperty("cust_orders")]
    public virtual Shipping_method? shipping_method { get; set; }
}
