using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReccomenderSystem.Data;
using ReccomenderSystem.DTOs;
using ReccomenderSystem.Helpers;
using ReccomenderSystem.Interfaces;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReccomenderSystem
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly ApplicationDbContext _context;

        public UserService(
            SignInManager<ApplicationUser> signManager,
            UserManager<ApplicationUser> userManager,
            IOptions<AppSettings> appSettings,
            ApplicationDbContext context)
        {
            _signManager = signManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _context = context;
        }
      
        public async Task<(User, string message)> Authenticate(LoginDTO _login)
        {
            // var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            //var ApplicationUser = new ApplicationUser { UserName = username };

            var user = new ApplicationUser();

            //if (IsValidEmailAddress(_login.Username))
            //{
            user = await _userManager.FindByEmailAsync(_login.UserName);
            //}
            //else
            //{
            //    user = await _userManager.FindByNameAsync(_login.Username);
            //    //return null;
            //}

            // return null if user not found
            if (user == null)
            {
                return (null, "This user does not exists!");
            }
            else if (user != null && await _userManager.CheckPasswordAsync(user, _login.Password))
            {
                var roleId = _context.UserRoles.Where(r => r.UserId == user.Id).FirstOrDefault();
                var roleName = _context.Roles.Where(r => r.Id == roleId.RoleId).FirstOrDefault().Name;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.ToString()),
                    new Claim(ClaimTypes.Role, roleName)
                    }),
                    Expires = roleName == "Student" ? DateTime.UtcNow.AddDays(365) : DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                var userResult = new User();

                    userResult = new User()
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        Role = roleName,
                        Token = token,
                        IdRole = roleId.RoleId,
                        Email = user.Email,
                        //isActive = user.isActive
                    };
                return (userResult, "");
            }
            return (null, "Credentials are not correct!");

        }
    }
}
