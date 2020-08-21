using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarServiceApp.Models;
using CarServiceApp.Models.DTOs;
using CarServiceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceApp.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : Controller
    {
        private UserService userService { get; set; }

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateUser(CreateUserDTO createUserDTO)
        {
            if(userService.AddUser(createUserDTO))
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteUser(int? id)
        {
            if (Int32.TryParse(id.ToString(), out int parsedId) && userService.DeleteUser(parsedId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize(Roles = "Administrator, Employee")]
        public IActionResult UpdateUser(UpdateUserDTO updateUserDTO)
        {
            if (User.IsInRole("Employee") &&
                (!Int32.TryParse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value, out int userId) ||
                updateUserDTO.Id != userId))
            {
                return BadRequest();
            }

            if (updateUserDTO != null && userService.UpdateUser((User)updateUserDTO))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Employee")]
        public IActionResult GetUserInfo(int? id)
        {
            if (id == null)
            {
                List<GetUserDTO> result = userService.GetUserList();

                if (result == null)
                    return NoContent();
                else
                    return Ok(result);
            }
            else
            {
                GetUserDTO result = userService.GetUser(Convert.ToInt32(id));

                if (result == null)
                    return NoContent();
                else
                    return Ok(result);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "Administrator")]
        public IActionResult UpdateUserRole(UpdateUserRoleDTO updateUserRoleDTO)
        {
            if(updateUserRoleDTO != null && userService.UpdateUser((User)updateUserRoleDTO))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
