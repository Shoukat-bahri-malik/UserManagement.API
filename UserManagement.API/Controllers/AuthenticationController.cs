using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;
using UserManagement.API.Models.Authentication.SignUp;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration  _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Reister([FromBody] RegisterUser registerUser, string role)
        {
            //Check Existing User

            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User already exists." });

            }

            //Add the new User In Db.

            IdentityUser user = new IdentityUser()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);


            return result.Succeeded ? StatusCode(StatusCodes.Status201Created, 
                                        new Response { Status = "Success", Message = "User Created Successfuly" }) :
                                      StatusCode(StatusCodes.Status201Created, 
                                         new Response { Status = "Success", Message = "User Created Successfuly" });
        }
    }
}
