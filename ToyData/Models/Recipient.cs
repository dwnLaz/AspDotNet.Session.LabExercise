using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("Recipient")]
    public partial class Recipient
    {
        [Key]
        [Column("cOrderNo")]
        [StringLength(6)]
        public string COrderNo { get; set; }
        [Required]
        [Column("vFirstName")]
        [StringLength(20)]
        public string VFirstName { get; set; }
        [Required]
        [Column("vLastName")]
        [StringLength(20)]
        public string VLastName { get; set; }
        [Required]
        [Column("vAddress")]
        [StringLength(20)]
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
        [Column("cPhone")]
        [StringLength(15)]
        public string CPhone { get; set; }

        [ForeignKey(nameof(CCountryId))]
        [InverseProperty(nameof(Country.Recipients))]
        public virtual Country CCountry { get; set; }
        [ForeignKey(nameof(COrderNo))]
        [InverseProperty(nameof(Order.Recipient))]
        public virtual Order COrderNoNavigation { get; set; }
    }
}
