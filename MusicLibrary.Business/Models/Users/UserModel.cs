using MusicLibrary.Business.Models.Album;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace MusicLibrary.Business.Models.Users
{
   public class UserModel : BaseModel
    {
        public UserModel()
        {
            Albums = new List<AlbumModel>();
        }
        public Guid Id { get; set; }
        [Required]
        
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public List<AlbumModel> Albums { get; set; }
        
    }
}
