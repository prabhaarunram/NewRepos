using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public partial class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? ItemPrice { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? TotalPrice { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Order")]
        public virtual Product Product { get; set; }
    }
}
