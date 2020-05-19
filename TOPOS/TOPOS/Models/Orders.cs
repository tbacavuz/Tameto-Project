using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TOPOS.Models
{
    public class Orders
    {
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public long Status { get; set; }

        
        [ForeignKey("Customers")]
        [DisplayName("Customer Name")]
        public long CustomersId { get; set; }
        public Customers Customers { get; set; }
    }
}