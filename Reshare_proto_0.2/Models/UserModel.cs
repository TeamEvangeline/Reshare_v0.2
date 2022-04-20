using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblUser")]
    public class UserModel
    {
        [Key]
        [Required]
        [Column("UserId")]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }

        [Column("PhoneNbr")]
        public string PhoneNumber { get; set; }

        public virtual int? LocationId { get; set; }
        public virtual LocationModel Location { get; set; }

        public virtual ICollection<ImageModel> Images { get; set; }

        public virtual ICollection<UserSaveModel> UserSaves { get; set; }
    }
}
