using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("ShippingRate")]
    public partial class ShippingRate
    {
        [Key]
        [Column("cCountryID")]
        [StringLength(3)]
        public string CCountryId { get; set; }
        [Key]
        [Column("cModeId")]
        [StringLength(2)]
        public string CModeId { get; set; }
        [Column("mRatePerPound", TypeName = "money")]
        public decimal MRatePerPound { get; set; }

        [ForeignKey(nameof(CCountryId))]
        [InverseProperty(nameof(Country.ShippingRates))]
        public virtual Country CCountry { get; set; }
        [ForeignKey(nameof(CModeId))]
        [InverseProperty(nameof(ShippingMode.ShippingRates))]
        public virtual ShippingMode CMode { get; set; }
    }
}
