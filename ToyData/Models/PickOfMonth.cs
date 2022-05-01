using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("PickOfMonth")]
    public partial class PickOfMonth
    {
        [Key]
        [Column("cToyId")]
        [StringLength(6)]
        public string CToyId { get; set; }
        [Key]
        [Column("siMonth")]
        public short SiMonth { get; set; }
        [Key]
        [Column("iYear")]
        public int IYear { get; set; }
        [Column("iTotalSold")]
        public int? ITotalSold { get; set; }

        [ForeignKey(nameof(CToyId))]
        [InverseProperty(nameof(Toy.PickOfMonths))]
        public virtual Toy CToy { get; set; }
    }
}
