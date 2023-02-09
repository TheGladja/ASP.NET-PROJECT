using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users;
            var usersToReturn = new List<UserDTO>();

            if (!users.Any())
            {
                return NotFound("There are no users left");
            }

            foreach (var user in users)
            {
                usersToReturn.Add(new UserDTO(user));
            }

            return Ok(usersToReturn);
        }

        [HttpGet]
        [Route("GetByUsername/{Username}")]
        public async Task<IActionResult> GetByUsername(string Username)
        {
            var user = await _userManager.FindByNameAsync(Username);

            if (user == null)
            {
                return NotFound("There is no user with that Username");
            }

            return Ok(new UserDTO(user));
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("UpdateUsername/{oldName}/{newName}")]
        public async Task<IActionResult> UpdateUsername(string oldName, string newName)
        {
            var user = await _userManager.FindByNameAsync(oldName);

            if (user == null)
            {
                return NotFound("There is no user with that Username");
            }

            user.UserName = newName;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok("Update succeded");
            }

            return NoContent();
        }
    }
}
