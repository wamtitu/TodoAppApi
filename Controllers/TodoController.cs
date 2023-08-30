using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using todoApi.Models;
using todoApi.Requests;
using todoApi.Responses;
using todoApi.Services.IServices;

namespace todoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _imapper;

        public TodoController(ITodoService todoService, IMapper imapper){
            _todoService = todoService;
            _imapper = imapper;
        }

        [HttpPost]
        public async Task<ActionResult<SuccessMessage>> AddTodos(AddTodo newTodo){
            var todo = _imapper.Map<Todo>(newTodo);
            var res = await _todoService.AddTodoAsync(todo);
            return CreatedAtAction(nameof(AddTodos), new SuccessMessage(201, res));
        }

        [HttpGet]
        public async Task<ActionResult<SuccessMessage>> GetTodos(){
            var todo = await _todoService.GetTodoAsync();
            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuccessMessage>> GetOneTodos(Guid id){
            var todo = await _todoService.GetOneTodoAsync(id);
            if(todo == null){
                return BadRequest(new SuccessMessage(400, "No todo with such id"));
            }
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessMessage>> deleteTodo(Guid id){
            var todo = await _todoService.GetOneTodoAsync(id);
            if (todo == null){
                return NotFound(new SuccessMessage(404, "cannot delete No user with id specified"));
            }
            var res = await _todoService.DeleteTodoAsync(todo);
            return Ok(new SuccessMessage(200, res));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> updateTodo(Guid id, AddTodo updatedTodo){
            var todo = await _todoService.GetOneTodoAsync(id);
            if(todo == null){
                return NotFound(new SuccessMessage(200, "no todo with specified id"));
            }
            var updated = _imapper.Map(updatedTodo, todo);
            var res = await _todoService.UpdateTodoAsync(updated);
            return Ok(new SuccessMessage(200, res));
        }
        
    }
}