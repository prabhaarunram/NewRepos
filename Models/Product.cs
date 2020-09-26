using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public partial class Product
    {
        public Product()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int ProductId { get; set; }
        [StringLength(150)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Price { get; set; }
        public int? TotalQuantity { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
