using AuthenticationService.DTO;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }       

        // POST api/<AuthController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            //if (loginModel == null)
            //    return Unauthorized("Please enter your credentials to login");
            var validUser = _authRepository.Login(loginModel);
            if (validUser == null)
                return Unauthorized("You are not a valid user... Please check your mail and password!!!");
            return Ok(validUser);
        }

       
    }
}
