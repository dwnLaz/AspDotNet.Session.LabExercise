using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("ShippingMode")]
    public partial class ShippingMode
    {
        public ShippingMode()
        {
            Orders = new HashSet<Order>();
            ShippingRates = new HashSet<ShippingRate>();
        }

        [Key]
        [Column("cModeId")]
        [StringLength(2)]
        public string CModeId { get; set; }
        [Required]
        [Column("cMode")]
        [StringLength(25)]
        public string CMode { get; set; }
        [Column("iMaxDelDays")]
        public int? IMaxDelDays { get; set; }

        [InverseProperty(nameof(Order.CShippingMode))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(ShippingRate.CMode))]
        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
    }
}
