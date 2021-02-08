using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.DAL.Entities
{
   public class MusicUsers
    {
        public Guid UserId { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
        public User User { get; set; }
    }
}
