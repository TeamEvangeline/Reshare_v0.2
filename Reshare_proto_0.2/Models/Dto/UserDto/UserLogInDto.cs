using System.ComponentModel.DataAnnotations;

namespace Reshare_proto_0._2.Models.Dto.UserDto
{
    public class UserLogInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
