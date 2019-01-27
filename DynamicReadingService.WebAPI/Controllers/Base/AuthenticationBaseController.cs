using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DynamicReadingService.Business.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DynamicReadingService.WebAPI.Controllers.Base
{
    public class AuthenticationBaseController : BaseController
    {
        public UserManager<IdentityUser> UserManager;
        public SignInManager<IdentityUser> SignInManager;
        public TokenConfig TokenConfig;

        public AuthenticationBaseController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            TokenConfig configuration
            )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            TokenConfig = configuration;
        }

        [NonAction]
        public string GenerateJwtToken(IdentityUser user, IList<Claim> claimsUser)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            claims.AddRange(claimsUser);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfig.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(TokenConfig.Days));

            var token = new JwtSecurityToken(
                TokenConfig.Issuer,
                TokenConfig.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}