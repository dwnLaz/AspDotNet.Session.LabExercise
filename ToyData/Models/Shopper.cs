using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("Shopper")]
    public partial class Shopper
    {
        public Shopper()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("cShopperId")]
        [StringLength(6)]
        public string CShopperId { get; set; }
        [Required]
        [Column("cPassword")]
        [StringLength(10)]
        public string CPassword { get; set; }
        [Required]
        [Column("vFirstName")]
        [StringLength(20)]
        public string VFirstName { get; set; }
        [Required]
        [Column("vLastName")]
        [StringLength(20)]
        public string VLastName { get; set; }
        [Required]
        [Column("vEmailId")]
        [StringLength(40)]
        public string VEmailId { get; set; }
        [Required]
        [Column("vAddress")]
        [StringLength(40)]
        public string VAddress { get; set; }
        [Required]
        [Column("cCity")]
        [StringLength(15)]
        public string CCity { get; set; }
        [Required]
        [Column("cState")]
        [StringLength(15)]
        public string CState { get; set; }
        [Column("cCountryId")]
        [StringLength(3)]
        public string CCountryId { get; set; }
        [Column("cZipCode")]
        [StringLength(10)]
        public string CZipCode { get; set; }
        [Required]
        [Column("cPhone")]
        [StringLength(15)]
        public string CPhone { get; set; }
        [Required]
        [Column("cCreditCardNo")]
        [StringLength(16)]
        public string CCreditCardNo { get; set; }
        [Required]
        [Column("vCreditCardType")]
        [StringLength(15)]
        public string VCreditCardType { get; set; }
        [Column("dExpiryDate", TypeName = "datetime")]
        public DateTime? DExpiryDate { get; set; }

        [ForeignKey(nameof(CCountryId))]
        [InverseProperty(nameof(Country.Shoppers))]
        public virtual Country CCountry { get; set; }
        [InverseProperty(nameof(Order.CShopper))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
