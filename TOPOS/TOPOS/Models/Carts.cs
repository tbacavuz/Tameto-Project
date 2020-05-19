using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TOPOS.Models
{
    public class Carts
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Customers")]
        public long CustomerId { get; set; }
        public Customers Customers { get; set; }
    }
}