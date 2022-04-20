using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblCountry", Schema = "dim")]
    public class CountryModel
    {
        [Key]
        [Required, Column("CountryId")]
        public int CountryId { get; set; }

        [Required, Column("CountryName")]
        public string CountryName { get; set; }

        [Required,Column("PhoneCode")]
        public string PhoneCode { get; set; }

        public StateModel State { get; set; }

        public LocationModel Location { get; set; }
    }
}
