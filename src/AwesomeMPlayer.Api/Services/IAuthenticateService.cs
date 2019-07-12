using AwesomeMPlayer.Api.Models;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Services
{
    public interface IAuthenticateService
    {
        Task<string> GetTokenAsync(UserCredentials userCredentials);
    }
}
