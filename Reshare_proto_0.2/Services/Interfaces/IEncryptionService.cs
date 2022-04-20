using System.Threading.Tasks;

namespace Reshare_proto_0._2.Services.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string input);

        string Decrypt(string input);
    }
}
