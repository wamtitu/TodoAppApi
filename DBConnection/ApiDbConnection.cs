using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoApi.Models;

namespace todoApi.DBConnection
{
    public class ApiDbConnection :DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users{ get; set; }

         public ApiDbConnection(DbContextOptions<ApiDbConnection> options):base(options){}
    }
}