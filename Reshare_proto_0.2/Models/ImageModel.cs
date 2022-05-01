using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblImages")]
    public class ImageModel
    {
        [Key]
        [Required]
        [Column("ImgId")]
        public int ImgId { get; set; }

        [Required]
        [Column("Url")]
        public string ImageLink { get; set; }

        public string ImageDesc { get; set; }

        [ForeignKey("FK_tblUsers_tblImages")]
        public int UserId { get; set; }
        public UserModel User { get; set; }

        public virtual ICollection<ImageCategoryModel> ImageCategories { get; set; }
    }
}
