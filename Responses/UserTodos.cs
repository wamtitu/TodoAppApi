using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Responses
{
    public class UserTodosDTO
    {
        public Guid UserId { get; set;}
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<TodosDTO> Todos { get; set; } = new List<TodosDTO>();
        
    }
    public class TodosDTO{
        public string Title { get; set;}
        public string Description { get; set;}
    }
}