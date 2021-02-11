using MusicLibrary.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicLibrary.Business.Models.Users
{
  public  class UserAuthModel

    {
        public Guid Id { get; set; }
        [Required]
       
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public UserRoles Role { get; set; }
    }
}
