﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ProductImage", Schema = "MAIN")]
    public partial class ProductImage
    {
        public ProductImage()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        public byte[] ImageData { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<Product> Product { get; set; }
    }
}