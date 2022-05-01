using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    public partial class Toy
    {
        public Toy()
        {
            OrderDetails = new HashSet<OrderDetail>();
            PickOfMonths = new HashSet<PickOfMonth>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        [Column("cToyId")]
        [StringLength(6)]
        public string CToyId { get; set; }
        [Required]
        [Column("vToyName")]
        [StringLength(20)]
        public string VToyName { get; set; }
        [Column("vToyDescription")]
        [StringLength(250)]
        public string VToyDescription { get; set; }
        [Column("cCategoryId")]
        [StringLength(3)]
        public string CCategoryId { get; set; }
        [Column("mToyRate", TypeName = "money")]
        public decimal MToyRate { get; set; }
        [Column("cBrandId")]
        [StringLength(3)]
        public string CBrandId { get; set; }
        [Column("imPhoto", TypeName = "image")]
        public byte[] ImPhoto { get; set; }
        [Column("siToyQoh")]
        public short SiToyQoh { get; set; }
        [Column("siLowerAge")]
        public short SiLowerAge { get; set; }
        [Column("siUpperAge")]
        public short SiUpperAge { get; set; }
        [Column("siToyWeight")]
        public short? SiToyWeight { get; set; }
        [Column("vToyImgPath")]
        [StringLength(50)]
        public string VToyImgPath { get; set; }

        [ForeignKey(nameof(CBrandId))]
        [InverseProperty(nameof(ToyBrand.Toys))]
        public virtual ToyBrand CBrand { get; set; }
        [ForeignKey(nameof(CCategoryId))]
        [InverseProperty(nameof(Category.Toys))]
        public virtual Category CCategory { get; set; }
        [InverseProperty(nameof(OrderDetail.CToy))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [InverseProperty(nameof(PickOfMonth.CToy))]
        public virtual ICollection<PickOfMonth> PickOfMonths { get; set; }
        [InverseProperty(nameof(ShoppingCart.CToy))]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
