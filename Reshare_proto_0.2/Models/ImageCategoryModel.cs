using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblImageCategories")]
    public class ImageCategoryModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
