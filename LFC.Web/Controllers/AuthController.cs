using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LFC.BLL.Interfaces;
using LFC.DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using LFC.BLL.Models;
using LoginModel = LFC.DAL.Models.LoginModel;

namespace LFC.Web.Controllers
{
    //[Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        /*public IActionResult Login()
        {
            return View();
        }*/

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/login");
            }

            try
            {
                var user = await _authService.LoginAsync(model);
                await LoginUser(user);
                
                return Redirect("/student");
            }
            catch (Exception e)
            {
                return Redirect("/login");
            }
            
        }

        private async Task LoginUser(User user)
        {
            var claims = new ClaimsIdentity(new[]
            {
                new Claim("Id", user.Id),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claims));
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/register");
            }

            try
            {
                await _authService.RegisterAsync(model);
            }
            catch (Exception e)
            {
                return Redirect("/register");
            }

            return Redirect("/login");
        }
    } 
}
