using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Requests
{
    public class AddTodo
    {
        [Required]
        public string Title { get; set;}
        [Required]
        public string Description { get; set;}
        [Required]
        public Guid UserId { get; set;}
    }
}