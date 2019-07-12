using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeMPlayer.Api.Models
{
    public class UserCredentials
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public bool UsernameIsEmail { get; set; }
    }
}
