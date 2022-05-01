using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column("cOrderNo")]
        [StringLength(6)]
        public string COrderNo { get; set; }
        [Key]
        [Column("cToyId")]
        [StringLength(6)]
        public string CToyId { get; set; }
        [Column("siQty")]
        public short SiQty { get; set; }
        [Column("cGiftWrap")]
        [StringLength(1)]
        public string CGiftWrap { get; set; }
        [Column("cWrapperId")]
        [StringLength(3)]
        public string CWrapperId { get; set; }
        [Column("vMessage")]
        [StringLength(256)]
        public string VMessage { get; set; }
        [Column("mToyCost", TypeName = "money")]
        public decimal? MToyCost { get; set; }

        [ForeignKey(nameof(COrderNo))]
        [InverseProperty(nameof(Order.OrderDetails))]
        public virtual Order COrderNoNavigation { get; set; }
        [ForeignKey(nameof(CToyId))]
        [InverseProperty(nameof(Toy.OrderDetails))]
        public virtual Toy CToy { get; set; }
        [ForeignKey(nameof(CWrapperId))]
        [InverseProperty(nameof(Wrapper.OrderDetails))]
        public virtual Wrapper CWrapper { get; set; }
    }
}
