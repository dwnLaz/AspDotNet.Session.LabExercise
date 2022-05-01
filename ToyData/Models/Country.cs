using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Recipients = new HashSet<Recipient>();
            ShippingRates = new HashSet<ShippingRate>();
            Shoppers = new HashSet<Shopper>();
        }

        [Key]
        [Column("cCountryId")]
        [StringLength(3)]
        public string CCountryId { get; set; }
        [Required]
        [Column("cCountry")]
        [StringLength(25)]
        public string CCountry { get; set; }

        [InverseProperty(nameof(Recipient.CCountry))]
        public virtual ICollection<Recipient> Recipients { get; set; }
        [InverseProperty(nameof(ShippingRate.CCountry))]
        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
        [InverseProperty(nameof(Shopper.CCountry))]
        public virtual ICollection<Shopper> Shoppers { get; set; }
    }
}
