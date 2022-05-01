using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToyData.Models
{
    [Table("Applicant")]
    public partial class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Column(TypeName = "decimal(11, 2)")]
        public decimal Salary { get; set; }
    }
}
