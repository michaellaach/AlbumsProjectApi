using MusicLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.DAL.Repositories.Interfaces
{
   public interface IUserRepository : IBaseRepository<User>
    {
        Task BoughtAlbum(Guid userId, Guid albumId);
        User GetUserWithAlbums(Guid id);
        IEnumerable<User> GetAllUsersWithAlbums(Expression<Func<User, bool>> filter = null);
        User GetUserByUsername(string username);
    }
}
