using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("ToyBrand")]
    public partial class ToyBrand
    {
        public ToyBrand()
        {
            Toys = new HashSet<Toy>();
        }

        [Key]
        [Column("cBrandId")]
        [StringLength(3)]
        public string CBrandId { get; set; }
        [Required]
        [Column("cBrandName")]
        [StringLength(20)]
        public string CBrandName { get; set; }

        [InverseProperty(nameof(Toy.CBrand))]
        public virtual ICollection<Toy> Toys { get; set; }
    }
}
