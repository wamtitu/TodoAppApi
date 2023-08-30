using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoApi.DBConnection;
using todoApi.Models;
using todoApi.Responses;
using todoApi.Services.IServices;

namespace todoApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApiDbConnection _context;

        public UserService(ApiDbConnection context){
            _context = context;
        }
        public async Task<string> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User added successfully";
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "user deleted successfully";
        }

    
        public async Task<IEnumerable<UserTodosDTO>> GetUsersAsync()
        {
            return await _context.Users.Select(i=> new UserTodosDTO(){
                UserId = i.UserId,
                UserName = i.UserName,
                Email = i.Email,
                Todos = i.Todos.Select(c=>new TodosDTO(){
                    Title = c.Title,
                    Description =c.Description
                }).ToList()
            }).ToListAsync();
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return "user updated successfully";
        }

        

       public async Task<UserTodosDTO> GetUserWithTodosAsync(Guid id)
        {
             return await _context.Users.Where(u=>u.UserId == id).Select(i=> new UserTodosDTO(){
                UserId = i.UserId,
                UserName = i.UserName,
                Email = i.Email,
                Todos = i.Todos.Select(c=>new TodosDTO(){
                    Title = c.Title,
                    Description =c.Description
                }).ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<User> GetOneUserAsync(Guid id)
        {
            return await _context.Users.Where(i => i.UserId == id).FirstOrDefaultAsync();
        }
    }
}