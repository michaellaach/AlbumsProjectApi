using MusicLibrary.DAL.Entities;
using MusicLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MusicLibraryContext context) : base(context)
        {

        }
    }
}
