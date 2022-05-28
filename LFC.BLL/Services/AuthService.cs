using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LFC.BLL.Interfaces;
using LFC.BLL.Models;
using LFC.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace LFC.BLL
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<User> _userManager;
        
        public AuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<User> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            
            var doPasswordsMatch = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!doPasswordsMatch)
            {
                throw new Exception("Invalid password");
            }

            return user;
        }

        public async Task RegisterAsync(RegisterDto model)
        {
            var userThatAlreadyExists = await _userManager.FindByEmailAsync(model.Email);
            if (userThatAlreadyExists != null)
            {
                throw new Exception("Email is already taken");
            }
            var user = new User()
            {
                Email = model.Email,
                UserRole = UserRole.Student,
            };

            var student = new Student()
            {
                UserId = user.Id,
                Name = model.Name,
                Surname = model.Surname,

            };
           

            user.Student = student;
            await _userManager.CreateAsync(user, model.Password);
        }
    }
}