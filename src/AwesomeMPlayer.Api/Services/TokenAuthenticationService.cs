using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AwesomeMPlayer.Api.Models;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Services
{
    public class TokenAuthenticationService: IAuthenticateService
    {
        private readonly IUserManagementService _userManagementService;
        private readonly TokenManagement _tokenManagement;

        public TokenAuthenticationService(IUserManagementService service, IOptions<TokenManagement> tokenManagement)
        {
            _userManagementService = service;
            _tokenManagement = tokenManagement.Value;
        }

        public async Task<string> GetTokenAsync(UserCredentials userCredentials)
        {
            var isValidUser = await _userManagementService.IsValidUserAsync(userCredentials);
            if (!isValidUser)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userCredentials.Username),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claims,
                expires: DateTime.Now.AddHours(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}
