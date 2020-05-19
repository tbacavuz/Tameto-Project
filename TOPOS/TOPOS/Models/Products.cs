using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TOPOS.Models
{
    public class Products
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Details { get; set; }

        [ForeignKey("ProductTypes")]
        public long ProductTypesId { get; set; }
        public ProductTypes ProductTypes { get; set; }
    }
}