using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblCity", Schema = "dim")]
    public class CityModel
    {
        [Key]
        [Required, Column("CityId")]
        public int CityId { get; set; }

        [Required, Column("CityName")]
        public string CityName { get; set; }

        [Required, Column("StateId")]
        public int StateId { get; set; }
        public StateModel State { get; set; }
    }
}
