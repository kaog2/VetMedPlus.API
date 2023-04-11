using Microsoft.AspNetCore.Mvc;
using VetMedPlus.API.Models;
using VetMedPlus.API.Services.Contracts;

namespace VetMedPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserData _userData;

        public UsersController(IUserData userData)
        {
            _userData = userData;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userData.GetAllUsers());
        }

        [HttpGet("GetUserById/{UserId:int}")]
        public async Task<IActionResult> GetUserById(int UserId)
        {
            return Ok(await _userData.GetUserById(UserId));
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                if (user.Username == string.Empty || user.Password == string.Empty)
                {
                    ModelState.AddModelError("Username or Password", "Username or Password could not be empty");
                }

                await _userData.AddUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the user: {ex.Message}");
            }
        }

        [HttpPost("AddUserAddress")]
        public async Task<IActionResult> AddUserAddress([FromBody] UserClientModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                await _userData.AddUserAddress(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the user: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                if (user.Username == string.Empty || user.Password == string.Empty)
                {
                    ModelState.AddModelError("Username or Password", "Username or Password could not be empty");
                }

                await _userData.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the user: {ex.Message}");
            }
        }
    }
}
