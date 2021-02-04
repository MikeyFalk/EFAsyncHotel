using EFAsyncHotel.Models.Api;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState);

        public Task<UserDTO> Authenticate(string username, string password);
                
    }
}
