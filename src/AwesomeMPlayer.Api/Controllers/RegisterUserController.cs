using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeMPlayer.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeMPlayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // POST api/RegisterUser
        [HttpPost]
        public async Task<ActionResult> RegisterUserAsync([FromBody] UserCredentials userCredentials)
        {
            var user = new User()
            {
                UserName = userCredentials.Username,
                Email = userCredentials.Email,
            };
            var result = await _userManager.CreateAsync(user, userCredentials.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}