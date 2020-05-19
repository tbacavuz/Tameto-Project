using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TOPOS.Models
{
    public class OrderDetails
    {
        [Key]
        public long Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Orders")]
        public long OrderId { get; set; }
        public Orders Orders { get; set; }


        [ForeignKey("Products")]
        public long ProductId { get; set; }
        public Products Products { get; set; }
    }
}