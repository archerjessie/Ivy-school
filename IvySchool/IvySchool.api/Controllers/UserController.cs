using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvySchool.api.ViewModel;
using IvySchool.Domain.Models;
using IvySchool.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IvySchool.api.Controllers
{
    /// <summary>
    /// Apis for user management.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create a user and assign a proper role
        /// </summary>
        /// <param name="user">the user object</param>
        /// <returns>Json object indicate whether it is successful.</returns>

        [HttpGet("admin")]
        public async Task<IActionResult> GetAdministrators()
        {

            var response = await _userService.GetAdministrators();
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegistration user)
        { 

            var response= await _userService.CreateUserAsync(user.Email, user.Name, user.Password, user.RoleId);
            return Ok(response);
        }

        [HttpPost("logInUser")]
        public async Task<IActionResult> LogInUser([FromBody]LoginRequest logInForm)
        {

            var response = await _userService.LoginUserAsync(logInForm.Email,logInForm.Password, HttpContext.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString());
            return Ok(response);
        }

    }
}
