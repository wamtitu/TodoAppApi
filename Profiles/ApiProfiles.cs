using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using todoApi.Models;
using todoApi.Requests;

namespace todoApi.Profiles
{
    public class ApiProfiles : Profile
    {
        public ApiProfiles(){
            //mapping addtodo to todo
            CreateMap<AddTodo, Todo>().ReverseMap();

            //mapping addUSer to user
            CreateMap<AddUser, User>().ReverseMap();
        }
        
    }
}