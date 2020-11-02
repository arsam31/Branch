using AutoMapper;
using Branch.Api.DTOs;
using Branch.Data.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Branch.Api.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegister,User>();
            CreateMap<User,UserRegister>();
            CreateMap<AddPost, Post>();
            CreateMap<Post,AddPost>();
            CreateMap<AddCategory, Category>();
            CreateMap<Category, AddCategory>();
            CreateMap<AddComment,Comments>();
            CreateMap<Comments, AddComment>();

        }
    }
}
