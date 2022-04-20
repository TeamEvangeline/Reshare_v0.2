using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblLocation", Schema = "dim")]
    public class LocationModel
    {
        [Key]
        [Required]
        public int LocationId { get; set; }

        public UserModel User { get; set; }

        public int CountryId { get; set; }
        public CountryModel Country { get; set; }
    }
}
