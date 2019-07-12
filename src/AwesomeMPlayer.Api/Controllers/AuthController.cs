using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeMPlayer.Api.Models;
using AwesomeMPlayer.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeMPlayer.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticateService _authService;

        public AuthController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        // POST api/auth
        [HttpPost]
        public async Task<ActionResult> RequestAsync([FromBody] UserCredentials userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _authService.GetTokenAsync(userCredentials);
            if (!string.IsNullOrEmpty(token))
            {
                return Ok(token);
            }
            
            return BadRequest("Invalid Request");
        }       
    }
}
