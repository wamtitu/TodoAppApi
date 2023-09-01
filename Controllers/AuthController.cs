using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using todoApi.Models;
using todoApi.Requests;
using todoApi.Services.IServices;

namespace todoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        public AuthController (IConfiguration config, IUserService userService){
            _config = config;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> LoginUser(NewLogin login){
            var user = await _userService.GetUserByEmailAsync(login.Email);
            if(user == null){
                return NotFound("Invalid credentials");
            }

            //user exists
            if(login.Password != user.Password){
               return BadRequest("invalid credentials") ;
            }
            var Token = CreateToken(user);
            
            return Ok(Token);
        }
        private string CreateToken(User user){
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentilas = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Audience"], _config["Jwt:Issuer"], null,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentilas
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
    }
}