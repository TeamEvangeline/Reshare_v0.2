using Reshare_proto_0._2.Models.Dto.UserDto;
using System.Threading.Tasks;

namespace Reshare_proto_0._2.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<bool> Register(UserRegisterDto user);

        Task<UserReadDto> LogIn(UserLogInDto user);
    }
}
