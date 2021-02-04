using EFAsyncHotel.Models.Api;
using EFAsyncHotel.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
     private IUserService userService;
     public UsersController(IUserService service)
     {
            userService = service;
     }
     [HttpPost("Register")]
     public async Task<ActionResult<UserDTO>> Register(RegisterUser data)
      {
         var user = await userService.Register(data, this.ModelState);
     

            if (ModelState.IsValid) 
            {
                return user;
            }
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user != null)
            { 
                return user;
            }
            return Unauthorized();

        }
    }
}
