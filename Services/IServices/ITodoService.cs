using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoApi.Models;
using todoApi.Requests;
using todoApi.Responses;

namespace todoApi.Services.IServices
{
    public interface ITodoService
    {
        Task<string> AddTodoAsync(Todo newTodo);
        Task<(List<Todo>, Pagination)> GetTodoAsync(int pageNumber, int pageSize);
        Task<Todo> GetOneTodoAsync(Guid id);
        Task<string> DeleteTodoAsync(Todo newTodo);
        Task<string> UpdateTodoAsync(Todo newTodo);
    }
}