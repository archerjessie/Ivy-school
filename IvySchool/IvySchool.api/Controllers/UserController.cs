using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvySchool.Domain.Models;
using IvySchool.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IvySchool.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        
        public IActionResult CreateUser([FromBody] User user)
        { 

            var response= _userService.CreateUser(user);
            return Ok(response);
        }

    }
}
