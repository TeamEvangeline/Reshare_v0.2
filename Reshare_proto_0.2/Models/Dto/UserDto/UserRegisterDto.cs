using System.ComponentModel.DataAnnotations;

namespace Reshare_proto_0._2.Models.Dto.UserDto
{
    public class UserRegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}
