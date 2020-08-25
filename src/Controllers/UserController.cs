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

        /// <summary>
        /// Create a user account.
        /// </summary>
        /// <param name="createUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Delete user account.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Change user account.
        /// </summary>
        /// <param name="updateUserDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Administrator, Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Get information about user accounts.
        /// </summary>
        /// <param name="id">Specific user id.</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Administrator, Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

        /// <summary>
        /// Change user role.
        /// </summary>
        /// <param name="updateUserRoleDTO"></param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUserRole(UpdateUserRoleDTO updateUserRoleDTO)
        {
            if(updateUserRoleDTO != null && userService.UpdateUserRole((User)updateUserRoleDTO))
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
