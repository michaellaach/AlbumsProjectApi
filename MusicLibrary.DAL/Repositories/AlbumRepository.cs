using MusicLibrary.DAL.Entities;
using MusicLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.DAL.Repositories
{
   public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(MusicLibraryContext context) : base(context)
        {

        }
    }
}
