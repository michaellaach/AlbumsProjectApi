using Microsoft.EntityFrameworkCore;
using MusicLibrary.DAL.Entities;
using MusicLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MusicLibrary.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IAlbumRepository _albumRepository;
        public UserRepository(MusicLibraryContext context, IAlbumRepository albumRepository) : base(context)
        {
            _albumRepository = albumRepository;
        }
        public IEnumerable<User> GetAllUsersWithAlbums(Expression<Func<User, bool>> filter = null)
        {
            if (filter != null)
            {
                return DbSet.Where(filter)
                    .Include(u => u.MusicUsers)
                    .ThenInclude(bu => bu.Album); ;
            }

            return DbSet.Include(u => u.MusicUsers)
                .ThenInclude(bu => bu.Album);
        }


        public async Task BoughtAlbum(Guid userId, Guid albumId)
        {
            var user = GetById(userId);
            var album = _albumRepository.GetById(albumId);
            album.QuantityInStock -= 1;
            var boughtAlbum = new MusicUsers { AlbumId = albumId };
            user.MusicUsers.Add(boughtAlbum);

            await Context.SaveChangesAsync();
        }

        public User GetUserWithAlbums(Guid id)
        {
            var result = DbSet.Include(u => u.MusicUsers)
                .ThenInclude(bu => bu.Album)
                .FirstOrDefault(x => x.Id == id);

            return result;
        }

        public User GetUserByUsername(string username)
        {
            var result = DbSet.FirstOrDefault(u => u.Username == username);

            return result;
        }
    }
}
