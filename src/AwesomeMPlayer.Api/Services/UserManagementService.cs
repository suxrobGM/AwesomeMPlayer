using AwesomeMPlayer.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly SignInManager<User> _signInManager;

        public UserManagementService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> IsValidUserAsync(UserCredentials userCredentials)
        {
            SignInResult result;
            if (userCredentials.UsernameIsEmail)
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(userCredentials.Username);
                result = await _signInManager.PasswordSignInAsync(user, userCredentials.Password, false, false);
            }
            else
            {
                result = await _signInManager.PasswordSignInAsync(userCredentials.Username, userCredentials.Password, false, false);
            }           

            return result.Succeeded;
        }
    }
}
