using EFAsyncHotel.Models.Api;
using EFAsyncHotel.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Controllers
{[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
     private IUserService userService;
     public UsersController(IUserService service)
     {
            userService = service;
     }

        [Authorize(Policy = "create")]
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
        [AllowAnonymous]
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

        [Authorize(Roles = "District Manager")] 
        //This annotation lets us protect any route based on user validation you can [Authorize] the whole page 
        //Use [AllowAnoymous] on individual routes in this case
        
        [HttpGet("me")]
        public async Task<ActionResult<UserDTO>> Me()
        {
            return await userService.GetUser(this.User);
        }
    }
}
