﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAsyncHotel.Models.Interfaces.Services
{
    public class JwtTokenService
    {
        private IConfiguration configuration;
        
        private SignInManager<ApplicationUser> signInManager;

        //validate secrets are hidden used by validator
        public static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                //Make sure the security key from configuration is valid
                IssuerSigningKey = GetSecurityKey(configuration),

                ValidateIssuer = false,
                ValidateAudience = false,
            };
        }
         
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secret = configuration["JWT:Secret"];
            if (secret == null) { throw new InvalidOperationException("JWT:Secret is missing"); }
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(secretBytes);
        }

        public async Task<string> GetToken(ApplicationUser user, System.TimeSpan expiresIn)
        {
            var principal = await signInManager.CreateUserPrincipalAsync(user);
            if(principal == null) { return null; }

            var signingKey = GetSecurityKey(configuration);
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow + expiresIn,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: principal.Claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
