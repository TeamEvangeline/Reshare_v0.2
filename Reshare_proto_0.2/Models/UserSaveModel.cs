using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblUserSaves")]
    public class UserSaveModel
    {
        [Key]
        [Required]
        public int UserSaveId { get; set; }

        //[Required]
        //public int UserId { get; set; }
        //public UserModel User { get; set; }

        //[Required]
        //public int ImageId { get; set; }
        //public ImageModel Image { get; set; }
    }
}
