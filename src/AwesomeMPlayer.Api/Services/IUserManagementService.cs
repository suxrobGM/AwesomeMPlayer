using AwesomeMPlayer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Services
{
    public interface IUserManagementService
    {
        Task<bool> IsValidUserAsync(UserCredentials userCredentials);
    }
}
