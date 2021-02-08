using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<MusicUsers> MusicUsers { get; set; } = new List<MusicUsers>();


    }
}
