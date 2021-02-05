using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Api
{
    public class RegisterUser
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        //You don't normally do this part users shouldn't be able to pick their own role.
        public List<string> Roles { get; set; }
    }
}
