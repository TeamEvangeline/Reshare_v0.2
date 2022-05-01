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

        public int CoountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }
    }
}
