using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TOPOS.Models.Enums;

namespace TOPOS.Models
{
    public class Orders
    {
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public long StatusId { get; set; }

        
        [ForeignKey("Customers")]
        [DisplayName("Customer Name")]
        public long CustomersId { get; set; }
        public Customers Customers { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

        [NotMapped]
        public StatusType StatusType
        {
            get
            {
                return (StatusType)StatusId;
            }
        }
    }
}