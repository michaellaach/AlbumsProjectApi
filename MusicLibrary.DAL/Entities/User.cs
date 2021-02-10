using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.DAL.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            MusicUsers = new List<MusicUsers>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<MusicUsers> MusicUsers { get; set; } = new List<MusicUsers>();


    }
}
