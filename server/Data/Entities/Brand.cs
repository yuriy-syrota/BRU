// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Brand", Schema = "REFERENCE")]
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty("Brand")]
        public virtual ICollection<Product> Product { get; set; }
    }
}