using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("Wrapper")]
    public partial class Wrapper
    {
        public Wrapper()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("cWrapperId")]
        [StringLength(3)]
        public string CWrapperId { get; set; }
        [Column("vDescription")]
        [StringLength(20)]
        public string VDescription { get; set; }
        [Column("mWrapperRate", TypeName = "money")]
        public decimal MWrapperRate { get; set; }
        [Column("imPhoto", TypeName = "image")]
        public byte[] ImPhoto { get; set; }
        [Column("vWrapperImgPath")]
        [StringLength(50)]
        public string VWrapperImgPath { get; set; }

        [InverseProperty(nameof(OrderDetail.CWrapper))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
