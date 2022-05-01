using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reshare_proto_0._2.Models
{
    [Table("tblState", Schema = "dim")]
    public class StateModel
    {
        [Key]
        [Required, Column("StateId")]
        public int StateId { get; set; }

        [Required, Column("StateName")]
        public string StateName { get; set; }

        [Required, Column("CountryId")]
        public string CountryId { get; set; }
        public CountryModel Country { get; set; }

        public virtual ICollection<CityModel> Cities { get; set; }
    }
}
