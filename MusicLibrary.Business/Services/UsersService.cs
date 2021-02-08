﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicLibrary.Business.Models;
using MusicLibrary.Business.Models.Users;
using MusicLibrary.Business.Services.Interfaces;
using MusicLibrary.DAL.Entities;
using MusicLibrary.DAL.Repositories;
using MusicLibrary.DAL.Repositories.Interfaces;

namespace MusicLibrary.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<User, bool>>>(filter);

            var result = _userRepository.GetAll(repoFilter);

            return _mapper.Map<List<UserModel>>(result);
        }

        public UserModel GetById(Guid id)
        {
            var result = _userRepository.GetById(id);
            return _mapper.Map<UserModel>(result);
        }

        public async Task InsertAsync(CreateUserModel model)
        {
            var entity = _mapper.Map<User>(model);
            await _userRepository.InsertAndSaveAsync(entity);

        }

        public async Task UpdateAsync(UserModel model)
        {
            var entity = _mapper.Map<User>(model);
            await _userRepository.UpdateAndSaveAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAndSaveAsync(id);
        }

    }
}
