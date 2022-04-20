using Reshare_proto_0._2.Models;
using Reshare_proto_0._2.Models.Dto.UserDto;
using System.Threading.Tasks;

namespace Reshare_proto_0._2.Repository.Interfaces
{
    public interface IUserIdentityRepo
    {
        public void Register(UserRegisterDto user);

        public Task<UserModel> LogIn(string email);
    }
}
