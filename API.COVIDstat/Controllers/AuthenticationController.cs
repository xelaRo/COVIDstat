using System.Threading.Tasks;
using API.COVIDstat.ViewModels;
using Domain.COVIDstat.DTOs;
using Domain.COVIDstat.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.COVIDstat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            if (string.IsNullOrEmpty((login.Email)) || string.IsNullOrEmpty((login.Password)) )
            {
                return BadRequest();
            }

            var token = await  _userService.AuthenticateUser(new UserDTO()
            {
                Email = login.Email,
                Password = login.Password
            });

            return Ok(token);
        }

        //public async Task<IActionResult> Logout()
        //{

        //}
    }
}
