using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        { 

            var response= await _userService.CreateUserAsync(user);
            return Ok(response);
        }

    }
}
