using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.Business.Models.Album
{
  public  class AlbumModel : BaseModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }

        [Min(0)]
        public int QuantityInStock { get; set; }
        
    }
}
 