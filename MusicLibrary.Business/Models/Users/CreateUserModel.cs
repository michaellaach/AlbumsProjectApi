using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicLibrary.Business.Models.Users
{
   public  class CreateUserModel : BaseModel
    {
        [Required]

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
