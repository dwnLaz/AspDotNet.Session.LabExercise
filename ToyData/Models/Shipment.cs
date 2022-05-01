using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("Shipment")]
    public partial class Shipment
    {
        [Key]
        [Column("cOrderNo")]
        [StringLength(6)]
        public string COrderNo { get; set; }
        [Column("dShipmentDate", TypeName = "datetime")]
        public DateTime? DShipmentDate { get; set; }
        [Column("cDeliveryStatus")]
        [StringLength(1)]
        public string CDeliveryStatus { get; set; }
        [Column("dActualDeliveryDate", TypeName = "datetime")]
        public DateTime? DActualDeliveryDate { get; set; }

        [ForeignKey(nameof(COrderNo))]
        [InverseProperty(nameof(Order.Shipment))]
        public virtual Order COrderNoNavigation { get; set; }
    }
}
