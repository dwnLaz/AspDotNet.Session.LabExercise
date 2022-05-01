using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        [Key]
        [Column("cCartId")]
        [StringLength(6)]
        public string CCartId { get; set; }
        [Key]
        [Column("cToyId")]
        [StringLength(6)]
        public string CToyId { get; set; }
        [Column("siQty")]
        public short SiQty { get; set; }

        [ForeignKey(nameof(CToyId))]
        [InverseProperty(nameof(Toy.ShoppingCarts))]
        public virtual Toy CToy { get; set; }
    }
}
