using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        public MappingProfile ()
        {
            CreateMap<User, CreateUserModel>().ReverseMap();

            CreateMap<Album, AlbumModel>().ReverseMap();
            CreateMap<Album, CreateAlbumModel>().ReverseMap();
            CreateMap<User, UserModel>()
                .ForMember(um => um.Albums, u=> u.MapFrom(x => x.MusicUsers.Select(bu => bu.Album)));
            CreateMap<UserModel, User>()
                    .ForMember(u => u.MusicUsers, um => um.MapFrom(x => x.Albums.Select(b => new MusicUsers { AlbumId = b.Id, UserId = x.Id })));
        }
    }
}
