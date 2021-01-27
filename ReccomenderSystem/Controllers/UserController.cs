using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ReccomenderSystem.DTOs;
using ReccomenderSystem.Interfaces;
using ReccomenderSystem.JWTFeatures;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReccomenderSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        //private readonly IStudentRepository _studentRepository;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly JwtHandler _jwtHandler;

        public UserController(
            SignInManager<ApplicationUser> signManager,
            UserManager<ApplicationUser> userManager,
            IUserService userService
        )
        {
            _signManager = signManager;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("Register/{firstName}/{lastName}/{email}/{interest}/{password}")]
        public async Task<IActionResult> Register(string firstName, string lastName, string email, int interest, string password)
        {
            try
            {
                var userExists = await _userManager.FindByEmailAsync(email.Trim());

                if (userExists != null)
                {
                    return BadRequest(new { message = "This user already exists. Please use your credentials to log in." });
                }



                var aspNetUser = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                    Firstname = firstName,
                    Lastname = lastName,
                    TopicId = interest
                };

                //Krijo userin e tije
                var result = await _userManager.CreateAsync(aspNetUser, password);

                if (!result.Succeeded)
                {
                    return BadRequest(new { message = "Could not create your user. Please try again." });
                }

                //Jepja rolin userit
                var addedToRole = await _userManager.AddToRoleAsync(aspNetUser, "Student");

                if (!addedToRole.Succeeded)
                {
                    return BadRequest(new { message = "Could not create your user. Please try again." });
                }

                return Ok(aspNetUser);
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex?.ToString() });
            }
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO userParam)
        {
            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            try
            {
                var user = await _userService.Authenticate(userParam);

                if (user.Item1 == null)
                    return BadRequest(new { message = user.message });

                //if (user.Item1.isActive == false)
                //{
                //    return BadRequest(new { message = "User is not active" });
                //}

                return Ok(user.Item1);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }


    }
}
