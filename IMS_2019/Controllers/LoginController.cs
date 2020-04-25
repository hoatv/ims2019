using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS_2019.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("/api/google-login")]
        public async Task LoginGoogle()
        {
            await HttpContext.ChallengeAsync("Google", new AuthenticationProperties() { RedirectUri = "/signin-google" });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/signin-google")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            //var info = await _signInManager.GetExternalLoginInfoAsync();

            // Sign in the user with this external login provider if the user already has a login.
            var result = await HttpContext.AuthenticateAsync("Cookies");
            //var result = await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            return BadRequest();
            //return null;
        }
    }
}
