using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoApi.Models;
using todoApi.Responses;

namespace todoApi.Services.IServices
{
    public interface IUserService
    {
        Task<string> AddUserAsync(User user);
        Task<string> UpdateUserAsync(User user);
        Task<string> DeleteUserAsync(User user);

        Task<IEnumerable<UserTodosDTO>> GetUsersAsync();
        Task<User> GetOneUserAsync(Guid id);

        Task<UserTodosDTO> GetUserWithTodosAsync(Guid id);
    }
}