﻿using EFAsyncHotel.Models.Api;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> userManager;
        public IdentityUserService(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }

       public async Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState)
        {
            //throw new NotImplementedException();
            var user = new ApplicationUser
                {
                    UserName = data.Username,
                    Email = data.Email,
                    PhoneNumber = data.PhoneNumber
                };
            var result = await userManager.CreateAsync(user, data.Password);

            if(result.Succeeded)
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            //Put errors into modelState
            //Ternary example below basically if then in one line of code conditionisTrue? good : if not then bad.
            foreach(var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";

                    modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (await userManager.CheckPasswordAsync(user, password))
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }
            return null;
        }
    }
}
