using Microsoft.EntityFrameworkCore;
using MusicLibrary.DAL.Entities;
using MusicLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IAlbumRepository _albumRepository;
        public UserRepository(MusicLibraryContext context, IAlbumRepository albumRepository) : base(context)
        {
            _albumRepository = albumRepository;
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

    }
}
