using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Keyless]
    public partial class VwOrderWrapper
    {
        [Required]
        [Column("cOrderNo")]
        [StringLength(6)]
        public string COrderNo { get; set; }
        [Required]
        [Column("cToyId")]
        [StringLength(6)]
        public string CToyId { get; set; }
        [Column("siQty")]
        public short SiQty { get; set; }
        [Column("vDescription")]
        [StringLength(20)]
        public string VDescription { get; set; }
        [Column("mWrapperRate", TypeName = "money")]
        public decimal MWrapperRate { get; set; }
    }
}
