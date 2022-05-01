using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("cOrderNo")]
        [StringLength(6)]
        public string COrderNo { get; set; }
        [Column("dOrderDate", TypeName = "datetime")]
        public DateTime DOrderDate { get; set; }
        [Required]
        [Column("cCartId")]
        [StringLength(6)]
        public string CCartId { get; set; }
        [Required]
        [Column("cShopperId")]
        [StringLength(6)]
        public string CShopperId { get; set; }
        [Column("cShippingModeId")]
        [StringLength(2)]
        public string CShippingModeId { get; set; }
        [Column("mShippingCharges", TypeName = "money")]
        public decimal? MShippingCharges { get; set; }
        [Column("mGiftWrapCharges", TypeName = "money")]
        public decimal? MGiftWrapCharges { get; set; }
        [Column("cOrderProcessed")]
        [StringLength(1)]
        public string COrderProcessed { get; set; }
        [Column("mTotalCost", TypeName = "money")]
        public decimal? MTotalCost { get; set; }
        [Column("dExpDelDate", TypeName = "datetime")]
        public DateTime? DExpDelDate { get; set; }

        [ForeignKey(nameof(CShippingModeId))]
        [InverseProperty(nameof(ShippingMode.Orders))]
        public virtual ShippingMode CShippingMode { get; set; }
        [ForeignKey(nameof(CShopperId))]
        [InverseProperty(nameof(Shopper.Orders))]
        public virtual Shopper CShopper { get; set; }
        [InverseProperty("COrderNoNavigation")]
        public virtual Recipient Recipient { get; set; }
        [InverseProperty("COrderNoNavigation")]
        public virtual Shipment Shipment { get; set; }
        [InverseProperty(nameof(OrderDetail.COrderNoNavigation))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
