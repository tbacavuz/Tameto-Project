using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TOPOS.Models
{
    public class Customers
    {
        [Key]
        public long Id { get; set; }

        [DisplayName("Name and Surname")]
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}