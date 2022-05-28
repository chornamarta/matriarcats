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
        
        public IActionResult Login()
        {
            return View();
        }

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
/*
public class AccountController: Controller {  
//Sample Users Data, it can be fetched with the use of any ORM    
public List < User > users = null;  
public AccountController() {  
    users = new List < User > ();  
    users.Add(new User() {  
        UserId = 1, Username = "Anoop", Password = "123", UserRole = (UserRole)Enum.GetValues(typeof(UserRole)).GetValue(0)
    });  
    users.Add(new User() {  
        UserId = 2, Username = "Other", Password = "123", UserRole = (UserRole)Enum.GetValues(typeof(UserRole)).GetValue(1)  
    });  
}  
public IActionResult Login(string ReturnUrl = "/") {  
        LoginModel objLoginModel = new LoginModel();  
        objLoginModel.ReturnUrl = ReturnUrl;  
        return View(objLoginModel);  
    }  
    [HttpPost]  
public async Task < IActionResult > Login(LoginModel objLoginModel) {  
    if (ModelState.IsValid) {  
        var user = users.Where(x => x.Username == objLoginModel.UserName && x.Password == objLoginModel.Password).FirstOrDefault();  
        if (user == null) {  
            //Add logic here to display some message to user    
            ViewBag.Message = "Invalid Credential";  
            return View(objLoginModel);  
        } else {  
            //A claim is a statement about a subject by an issuer and    
            //represent attributes of the subject that are useful in the context of authentication and authorization operations.    
            var claims = new List < Claim > () {  
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),  
                    new Claim(ClaimTypes.Name, user.Username),  
                    //new Claim(ClaimTypes.Role, user.UserRole),  
                    new Claim("FavoriteDrink", "Tea")  
            };  
            //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);  
            //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
            var principal = new ClaimsPrincipal(identity);  
            //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() {  
                IsPersistent = objLoginModel.RememberLogin  
            });  
            return LocalRedirect(objLoginModel.ReturnUrl);  
        }  
    }  
    return View(objLoginModel);  
}  
public async Task < IActionResult > LogOut() {  
    //SignOutAsync is Extension method for SignOut    
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);  
    //Redirect to home page    
    return LocalRedirect("/");  
}  /*
}   
}