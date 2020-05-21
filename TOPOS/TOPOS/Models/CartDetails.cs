using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TOPOS.Models
{
    public class CartDetails
    {
        [Key]
        public long Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Carts")]
        public long CartsId { get; set; }
        public Carts Carts { get; set; }


        [ForeignKey("Products")]
        public long ProductId { get; set; }
        public Products Products { get; set; }

        [NotMapped]
        public double? Price { get => Quantity * Products?.Price; }
    }
}