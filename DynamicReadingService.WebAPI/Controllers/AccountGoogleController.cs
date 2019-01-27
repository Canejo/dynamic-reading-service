using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DynamicReadingService.Business.Config;
using DynamicReadingService.Common.Config;
using DynamicReadingService.Common.Primitivo;
using DynamicReadingService.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicReadingService.WebAPI.Controllers
{
    public class AccountGoogleController : AuthenticationBaseController
    {
        private readonly SistemaConfig _sistemaConfig;

        public AccountGoogleController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            SistemaConfig sistemaConfig,
            TokenConfig configuration
            )
            : base(userManager, signInManager, configuration)
        {
            _sistemaConfig = sistemaConfig;
        }

        public IActionResult SignInWithGoogle()
        {
            var authenticationProperties = SignInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action(nameof(HandleExternalLogin)));
            return Challenge(authenticationProperties, "Google");
        }

        public async Task<IActionResult> HandleExternalLogin()
        {
            var info = await SignInManager.GetExternalLoginInfoAsync();

            var result = await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            if (!result.Succeeded) //user does not exist yet
            {
                var newUser = new IdentityUser
                {
                    UserName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                    Email = email,
                    EmailConfirmed = true
                };
                var createResult = await UserManager.CreateAsync(newUser);
                if (!createResult.Succeeded)
                    return Redirect(this.GetUrlError(createResult.Errors.Select(e => e.Description).Aggregate((errors, error) => $"{errors}, {error}")));

                await UserManager.AddLoginAsync(newUser, info);
                var newUserClaims = info.Principal.Claims.Append(new Claim("userId", newUser.Id));
                await UserManager.AddClaimsAsync(newUser, newUserClaims);
            }

            var appUser = UserManager.Users.SingleOrDefault(r => r.Email == email);
            var claims = await UserManager.GetClaimsAsync(appUser);

            string tokenString = GenerateJwtToken(appUser, claims);

            return Redirect(this.GetUrlSuccess(tokenString));
        }

        public string GetUrlSuccess(string token)
        {
            Uri baseUri = new Uri(_sistemaConfig.UrlWeb);
            Uri successUri = new Uri(baseUri, "user/google-success");
            var uriBuilder = new UriBuilder(successUri)
            {
                Query = $"?Token={StringExtensions.Base64Encode(token)}"
            };

            return uriBuilder.ToString();
        }

        public string GetUrlError(string error)
        {
            Uri baseUri = new Uri(_sistemaConfig.UrlWeb);
            Uri errorUri = new Uri(baseUri, "user/login");
            var uriBuilder = new UriBuilder(errorUri)
            {
                Query = $"?Error={StringExtensions.Base64Encode(error)}"
            };

            return uriBuilder.ToString();
        }
    }
}