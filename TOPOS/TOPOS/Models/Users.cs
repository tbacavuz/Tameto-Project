using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TOPOS.Models
{
    public class Users
    {
        [Key]
        public long Id { get; set; }
        
        [DisplayName("Name and Surname")]
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]
        public long RolesId { get; set; }
        public Roles Roles { get; set; }
    }
}