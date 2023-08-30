using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Models
{
    public class Todo
    {
        public Guid TodoId { get; set;}
        public string Title { get; set;}
        public string Description { get; set;}
        public User User { get; set;}
        public Guid UserId { get; set;}
    }
}