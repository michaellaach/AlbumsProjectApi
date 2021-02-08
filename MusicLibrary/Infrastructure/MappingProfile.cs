using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Business.Models;
using MusicLibrary.Business.Models.Album;
using MusicLibrary.Business.Models.Users;
using MusicLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();

            CreateMap<Album, AlbumModel>().ReverseMap();
            CreateMap<Album, CreateAlbumModel>().ReverseMap();

        }
    }
}
