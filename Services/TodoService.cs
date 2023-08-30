using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoApi.DBConnection;
using todoApi.Models;
using todoApi.Requests;
using todoApi.Services.IServices;

namespace todoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApiDbConnection _context;

        public TodoService (ApiDbConnection context){
            _context = context;
        }
        public async Task<string> AddTodoAsync(Todo newTodo)
        {
            _context.Todos.Add(newTodo);
            await _context.SaveChangesAsync();
            return "Todo added successfully";
        }

        public async Task<string> DeleteTodoAsync(Todo newTodo)
        {
            _context.Todos.Remove(newTodo);
            await _context.SaveChangesAsync();
            return "Todo deleted successfully";
        }

        public async Task<Todo> GetOneTodoAsync(Guid id)
        {
           return await _context.Todos.Where(u=>u.TodoId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Todo>> GetTodoAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<string> UpdateTodoAsync(Todo newTodo)
        {
            _context.Todos.Update(newTodo);
            await _context.SaveChangesAsync();
            return "Todo updated successfully";
        }
    }
}