using MusicLibrary.Business.Models;
using MusicLibrary.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicLibrary.Business.Services.Interfaces
{
    public interface IUsersService 
    {
        Task DeleteAsync(Guid id);
        List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter = null);
        UserModel GetById(Guid id);
        Task InsertAsync(CreateUserModel model);
        Task UpdateAsync(UserModel model);
        Task BoughtAlbum(Guid userId, Guid albumId);
        UserModel GetUserWithAlbums(Guid id);
        List<UserModel> GetAllUsersWithAlbums(Expression<Func<UserModel, bool>> filter = null);
        UserAuthModel GetUserByUsername(string username);
        bool DoesUsernameExist(string username);
    }
}