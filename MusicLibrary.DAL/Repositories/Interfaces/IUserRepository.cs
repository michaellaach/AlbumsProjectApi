using MusicLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.DAL.Repositories.Interfaces
{
   public interface IUserRepository : IBaseRepository<User>
    {
        Task BoughtAlbum(Guid userId, Guid albumId);
        User GetUserWithAlbums(Guid id);
    }
}
