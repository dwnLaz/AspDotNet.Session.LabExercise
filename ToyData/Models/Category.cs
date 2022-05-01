using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Toys = new HashSet<Toy>();
        }

        [Key]
        [Column("cCategoryId")]
        [StringLength(3)]
        public string CCategoryId { get; set; }
        [Required]
        [Column("cCategory")]
        [StringLength(20)]
        public string CCategory { get; set; }
        [Column("vDescription")]
        [StringLength(100)]
        public string VDescription { get; set; }

        [InverseProperty(nameof(Toy.CCategory))]
        public virtual ICollection<Toy> Toys { get; set; }
    }
}
