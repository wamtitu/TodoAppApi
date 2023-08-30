using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todoApi.Models;
using todoApi.Requests;
using todoApi.Responses;
using todoApi.Services.IServices;

namespace todoApi.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class UserController :ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper  _imapper;

        public UserController(IUserService userService, IMapper imapper)
        {
            _userService = userService;
            _imapper = imapper;
        }

        [HttpPost]
        public async Task<ActionResult<SuccessMessage>> addUsers(AddUser newUser){
            var user = _imapper.Map<User>(newUser);
            var res = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(addUsers), new SuccessMessage(201, res));
        }

        [HttpGet]
        public async Task<ActionResult<SuccessMessage>> getUsers(){
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserTodosDTO>> getUsers(Guid id){
            var user = await _userService.GetUserWithTodosAsync(id);
            if(user == null){
                return NotFound(new SuccessMessage(404, "No user found with that id"));
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<SuccessMessage>> deleteUsers(Guid id){
            var user = await _userService.GetOneUserAsync(id);
            if (user == null){
                return NotFound(new SuccessMessage(404, "cannot delete No user with id specified"));
            }
            var res = await _userService.DeleteUserAsync(user);
            return Ok(new SuccessMessage(200, res));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> updateUsers(Guid id, AddUser updatedUSer){
            var user =  await _userService.GetOneUserAsync(id);
            if(user == null){
                return NotFound(new SuccessMessage(404, "no user found with the specified id"));
            }
            var updated = _imapper.Map(updatedUSer, user);
            var res = await _userService.UpdateUserAsync(updated);
            return Ok(new SuccessMessage(200, res));
        }
        
    }
}